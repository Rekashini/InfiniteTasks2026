using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace TrainReservationSystem
{
    class BookingOperation
    {
        DBHandler db = new DBHandler();

        public void BookTicket()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("Enter Train No: ");
            int no = int.Parse(Console.ReadLine());

            con.Open();

            // CHECK TRAIN STATUS
            SqlCommand st = new SqlCommand(
                "SELECT Status FROM TrainDetails WHERE TrainNo=@n", con);

            st.Parameters.AddWithValue("@n", no);

            string status = st.ExecuteScalar().ToString();

            if (status == "Cancelled")
            {
                Console.WriteLine("Train Cancelled");
                con.Close();
                return;
            }

            // SHOW CLASSES
            SqlCommand show = new SqlCommand(
                @"SELECT Class,Availability,Charges
                  FROM TrainClassDetails
                  WHERE TrainNo=@n", con);

            show.Parameters.AddWithValue("@n", no);

            SqlDataReader sdr = show.ExecuteReader();

            Console.WriteLine();
            Console.WriteLine("CLASS | AVAILABLE | CHARGES");
            Console.WriteLine("-----------------------------");

            while (sdr.Read())
            {
                Console.WriteLine(
                    sdr["Class"] + " | " +
                    sdr["Availability"] + " | " +
                    sdr["Charges"]);
            }

            sdr.Close();

            Console.Write("\nTravel Date: ");
            DateTime td = DateTime.Parse(Console.ReadLine());

            // VALIDATION
            if (td < DateTime.Today)
            {
                Console.WriteLine("Invalid Travel Date");
                con.Close();
                return;
            }

            Console.Write("Choose Class: ");
            string cls = Console.ReadLine();

            Console.Write("Passengers Max 3: ");
            int p = int.Parse(Console.ReadLine());

            if (p > 3)
            {
                Console.WriteLine("Only 3 Passengers Allowed");
                con.Close();
                return;
            }

            SqlTransaction tx = con.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT Availability,Charges
                      FROM TrainClassDetails
                      WHERE TrainNo=@n
                      AND Class=@c", con, tx);

                cmd.Parameters.AddWithValue("@n", no);
                cmd.Parameters.AddWithValue("@c", cls);

                SqlDataReader dr = cmd.ExecuteReader();

                int av = 0;
                float ch = 0;

                if (dr.Read())
                {
                    av = (int)dr["Availability"];
                    ch = Convert.ToSingle(dr["Charges"]);
                }

                dr.Close();

                if (av < p)
                {
                    Console.WriteLine("Seats Not Available");
                    tx.Rollback();
                    return;
                }

                float amount = p * ch;

                Console.WriteLine("\nTotal Amount: " + amount);

                Console.WriteLine("\n1 UPI");
                Console.WriteLine("2 Card");
                Console.WriteLine("3 Net Banking");
                Console.WriteLine("4 Cash");

                int pay = int.Parse(Console.ReadLine());

                string payment = "";

                switch (pay)
                {
                    case 1:
                        payment = "UPI";
                        break;

                    case 2:
                        payment = "Card";
                        break;

                    case 3:
                        payment = "Net Banking";
                        break;

                    case 4:
                        payment = "Cash";
                        break;
                }

                // PNR
                string pnr = "PNR" +
                    new Random().Next(100000, 999999);

                SqlCommand ins = new SqlCommand(
                    @"INSERT INTO BookingDetails
                    VALUES(@pnr,@u,GETDATE(),
                    @td,@n,@c,@p,@amt,@pay,'Confirmed')",
                    con, tx);

                ins.Parameters.AddWithValue("@pnr", pnr);
                ins.Parameters.AddWithValue("@u", Session.LoggedInUser);
                ins.Parameters.AddWithValue("@td", td);
                ins.Parameters.AddWithValue("@n", no);
                ins.Parameters.AddWithValue("@c", cls);
                ins.Parameters.AddWithValue("@p", p);
                ins.Parameters.AddWithValue("@amt", amount);
                ins.Parameters.AddWithValue("@pay", payment);

                ins.ExecuteNonQuery();

                SqlCommand getid = new SqlCommand(
                    "SELECT MAX(BookingId) FROM BookingDetails",
                    con, tx);

                int bid = Convert.ToInt32(getid.ExecuteScalar());

                List<string> passengerNames = new List<string>();

                // PASSENGERS
                for (int i = 1; i <= p; i++)
                {
                    Console.WriteLine("\nPassenger " + i);

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    passengerNames.Add(name);

                    Console.Write("Age: ");
                    int age = int.Parse(Console.ReadLine());

                    if (age <= 0)
                    {
                        Console.WriteLine("Invalid Age");
                        tx.Rollback();
                        return;
                    }

                    Console.Write("Gender: ");
                    string gender = Console.ReadLine();

                    Console.Write("Identity Proof: ");
                    string id = Console.ReadLine();

                    Console.Write("Mobile Number: ");
                    string mobile = Console.ReadLine();

                    if (mobile.Length != 10)
                    {
                        Console.WriteLine("Invalid Mobile Number");
                        tx.Rollback();
                        return;
                    }

                    SqlCommand pcmd = new SqlCommand(
                        @"INSERT INTO PassengerDetails
                        VALUES(@bid,@name,@age,@g,@id,@m)",
                        con, tx);

                    pcmd.Parameters.AddWithValue("@bid", bid);
                    pcmd.Parameters.AddWithValue("@name", name);
                    pcmd.Parameters.AddWithValue("@age", age);
                    pcmd.Parameters.AddWithValue("@g", gender);
                    pcmd.Parameters.AddWithValue("@id", id);
                    pcmd.Parameters.AddWithValue("@m", mobile);

                    pcmd.ExecuteNonQuery();
                }

                // UPDATE SEATS
                SqlCommand up = new SqlCommand(
                    @"UPDATE TrainClassDetails
                      SET Availability=Availability-@p
                      WHERE TrainNo=@n
                      AND Class=@c", con, tx);

                up.Parameters.AddWithValue("@p", p);
                up.Parameters.AddWithValue("@n", no);
                up.Parameters.AddWithValue("@c", cls);

                up.ExecuteNonQuery();

                tx.Commit();

                // RECEIPT
                Console.WriteLine();
                Console.WriteLine("========= TRAIN TICKET =========");
                Console.WriteLine("PNR: " + pnr);
                Console.WriteLine("Train No: " + no);
                Console.WriteLine("Class: " + cls);

                Console.WriteLine("Passengers:");
                for (int i = 0; i < passengerNames.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + passengerNames[i]);
                }

                Console.WriteLine("Amount: " + amount);
                Console.WriteLine("Payment: " + payment);
                Console.WriteLine("Status: Confirmed");
                Console.WriteLine("================================");
            }
            catch
            {
                tx.Rollback();
                Console.WriteLine("Booking Failed");
            }

            con.Close();
        }

        // VIEW USER BOOKINGS
        public void ViewBookings()
        {
            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand(
                @"SELECT *
                  FROM BookingDetails
                  WHERE UserEmail=@u", con);

            cmd.Parameters.AddWithValue("@u",
                Session.LoggedInUser);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine();
            Console.WriteLine(
                "BookingId | PNR | Train | Class | Passengers | Amount | Status");

            Console.WriteLine(
                "---------------------------------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(
                    dr["BookingId"] + " | " +
                    dr["PNR"] + " | " +
                    dr["TrainNo"] + " | " +
                    dr["TravelClass"] + " | " +
                    dr["Passengers"] + " | " +
                    dr["Amount"] + " | " +
                    dr["BookingStatus"]);
            }

            con.Close();
        }

        // VIEW PASSENGERS
        public void ViewPassengers()
        {
            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand(
                @"SELECT pd.*
                  FROM PassengerDetails pd
                  JOIN BookingDetails bd
                  ON pd.BookingId=bd.BookingId
                  WHERE bd.UserEmail=@u", con);

            cmd.Parameters.AddWithValue("@u",
                Session.LoggedInUser);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine();
            Console.WriteLine(
                "PassengerId | BookingId | Name | Age | Gender | Mobile");

            Console.WriteLine(
                "-------------------------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(
                    dr["PassengerId"] + " | " +
                    dr["BookingId"] + " | " +
                    dr["PassengerName"] + " | " +
                    dr["Age"] + " | " +
                    dr["Gender"] + " | " +
                    dr["MobileNo"]);
            }

            con.Close();
        }
    }
}