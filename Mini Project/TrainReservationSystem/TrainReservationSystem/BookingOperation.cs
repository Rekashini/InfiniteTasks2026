using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TrainReservationSystem;

class BookingOperation
{
    DBHandler db = new DBHandler();

    public void BookTicket()
    {
        SqlConnection con = db.GetConnection();
        con.Open();

        Console.Write("Train No: ");
        int train = int.Parse(Console.ReadLine());

        Console.Write("Class: ");
        string cls = Console.ReadLine();

        Console.Write("Travel Date: ");
        DateTime td = DateTime.Parse(Console.ReadLine());

        Console.Write("Passengers (max 3): ");
        int count = int.Parse(Console.ReadLine());

        if (count < 1 || count > 3)
        {
            Console.WriteLine("Only 1 to 3 allowed");
            return;
        }

        List<(string n, int a, string g)> list = new();

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Passenger " + (i + 1));

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            list.Add((name, age, gender));
        }

        SqlTransaction tx = con.BeginTransaction();

        try
        {
            string pnr = "PNR" + new Random().Next(1000, 9999);

            SqlCommand ins = new SqlCommand(
                @"INSERT INTO BookingDetails
                VALUES(@p,@u,@n,@a,@g,'0000000000',GETDATE(),@td,@t,@c,@amt,'Cash','Confirmed');
                SELECT SCOPE_IDENTITY();",
                con, tx);

            ins.Parameters.AddWithValue("@p", pnr);
            ins.Parameters.AddWithValue("@u", Session.LoggedInUser);
            ins.Parameters.AddWithValue("@n", list[0].n);
            ins.Parameters.AddWithValue("@a", list[0].a);
            ins.Parameters.AddWithValue("@g", list[0].g);
            ins.Parameters.AddWithValue("@td", td);
            ins.Parameters.AddWithValue("@t", train);
            ins.Parameters.AddWithValue("@c", cls);
            ins.Parameters.AddWithValue("@amt", count * 500);

            int bookingId = Convert.ToInt32(ins.ExecuteScalar());

            foreach (var p in list)
            {
                SqlCommand pcmd = new SqlCommand(
                    "INSERT INTO PassengerDetails VALUES(@b,@n,@a,@g)",
                    con, tx);

                pcmd.Parameters.AddWithValue("@b", bookingId);
                pcmd.Parameters.AddWithValue("@n", p.n);
                pcmd.Parameters.AddWithValue("@a", p.a);
                pcmd.Parameters.AddWithValue("@g", p.g);

                pcmd.ExecuteNonQuery();
            }

            SqlCommand up = new SqlCommand(
                @"UPDATE TrainClassDetails
                SET Availability = Availability - @c
                WHERE TrainNo=@t AND Class=@cl",
                con, tx);

            up.Parameters.AddWithValue("@c", count);
            up.Parameters.AddWithValue("@t", train);
            up.Parameters.AddWithValue("@cl", cls);

            up.ExecuteNonQuery();

            tx.Commit();

            Console.WriteLine("Booking Success");
        }
        catch
        {
            tx.Rollback();
            Console.WriteLine("Failed");
        }

        con.Close();
    }
}