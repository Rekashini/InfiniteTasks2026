using System;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    class TrainOperation
    {
        DBHandler db = new DBHandler();

        public void AddTrain()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("Train No: ");
            int no = int.Parse(Console.ReadLine());

            Console.Write("Train Name: ");
            string name = Console.ReadLine();

            Console.Write("From Place: ");
            string from = Console.ReadLine();

            Console.Write("To Place: ");
            string to = Console.ReadLine();

            con.Open();

            SqlCommand cmd = new SqlCommand(
                @"INSERT INTO TrainDetails
                VALUES(@n,@name,@f,@t,'Active')", con);

            cmd.Parameters.AddWithValue("@n", no);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@f", from);
            cmd.Parameters.AddWithValue("@t", to);

            cmd.ExecuteNonQuery();

            string[] classes = { "Sleeper", "2AC", "3AC" };

            foreach (string cls in classes)
            {
                Console.Write($"Seats for {cls}: ");
                int av = int.Parse(Console.ReadLine());

                Console.Write($"Charges for {cls}: ");
                float ch = float.Parse(Console.ReadLine());

                SqlCommand ccmd = new SqlCommand(
                    @"INSERT INTO TrainClassDetails
                    VALUES(@n,@c,@a,@ch)", con);

                ccmd.Parameters.AddWithValue("@n", no);
                ccmd.Parameters.AddWithValue("@c", cls);
                ccmd.Parameters.AddWithValue("@a", av);
                ccmd.Parameters.AddWithValue("@ch", ch);

                ccmd.ExecuteNonQuery();
            }

            con.Close();

            Console.WriteLine("Train Added");
        }

        public void SearchTrain()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("From Place: ");
            string from = Console.ReadLine();

            Console.Write("To Place: ");
            string to = Console.ReadLine();

            SqlCommand cmd = new SqlCommand(
                @"SELECT td.TrainNo,
                 td.TrainName,
                 td.Status,
                 tcd.Class,
                 tcd.Availability,
                 tcd.Charges
          FROM TrainDetails td
          JOIN TrainClassDetails tcd
          ON td.TrainNo = tcd.TrainNo
          WHERE td.FromPlace=@f
          AND td.ToPlace=@t
          ORDER BY td.TrainNo", con);

            cmd.Parameters.AddWithValue("@f", from);
            cmd.Parameters.AddWithValue("@t", to);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            int currentTrain = -1;

            while (dr.Read())
            {
                int trainNo = Convert.ToInt32(dr["TrainNo"]);

                if (trainNo != currentTrain)
                {
                    currentTrain = trainNo;

                    Console.WriteLine();
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Train No   : " + dr["TrainNo"]);
                    Console.WriteLine("Train Name : " + dr["TrainName"]);
                    Console.WriteLine("Status     : " + dr["Status"]);
                    Console.WriteLine("----------------------------------");

                    Console.WriteLine("CLASS | AVAILABLE | CHARGES");
                    Console.WriteLine("-----------------------------");
                }

                Console.WriteLine(
                    dr["Class"] + " | " +
                    dr["Availability"] + " | " +
                    dr["Charges"]);
            }

            dr.Close();
            con.Close();
        }

        public void CancelTrain()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("Train No: ");
            int no = int.Parse(Console.ReadLine());

            SqlCommand cmd = new SqlCommand(
                "UPDATE TrainDetails SET Status='Cancelled' WHERE TrainNo=@n", con);

            cmd.Parameters.AddWithValue("@n", no);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Train Cancelled");
        }
    }
}