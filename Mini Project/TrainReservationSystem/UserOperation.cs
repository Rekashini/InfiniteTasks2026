using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace TrainReservationSystem
{
    class UserOperation
    {
        DBHandler db = new DBHandler();

        public void CreateUser()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            if (!Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Console.WriteLine("Invalid Email");
                return;
            }

            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Users VALUES(@e,@p,'User',1)", con);

            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@p", pass);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("User Created");
        }

        public string Login()
        {
            SqlConnection con = db.GetConnection();

            Console.WriteLine("1 Admin");
            Console.WriteLine("2 User");

            int ch = int.Parse(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Password: ");
            string pass = Console.ReadLine();

            string role = ch == 1 ? "Admin" : "User";

            SqlCommand cmd = new SqlCommand(
                @"SELECT UserType
                  FROM Users
                  WHERE Email=@e
                  AND Password=@p
                  AND UserType=@r", con);

            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@p", pass);
            cmd.Parameters.AddWithValue("@r", role);

            con.Open();

            object result = cmd.ExecuteScalar();

            con.Close();

            if (result != null)
            {
                Session.LoggedInUser = email;

                Console.WriteLine("Login Success");
                return result.ToString();
            }

            Console.WriteLine("Invalid Login");
            return null;
        }
    }
}