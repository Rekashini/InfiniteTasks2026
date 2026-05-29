using System;
using System.Data.SqlClient;
using TrainReservationSystem;

class UserOperation
{
    DBHandler db = new DBHandler();

    public void CreateUser()
    {
        SqlConnection con = db.GetConnection();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
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

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string pass = Console.ReadLine();

        SqlCommand cmd = new SqlCommand(
            "SELECT UserType FROM Users WHERE Email=@e AND Password=@p", con);

        cmd.Parameters.AddWithValue("@e", email);
        cmd.Parameters.AddWithValue("@p", pass);

        con.Open();

        object role = cmd.ExecuteScalar();
        con.Close();

        if (role != null)
        {
            Session.LoggedInUser = email;
            return role.ToString();
        }

        Console.WriteLine("Invalid Login");
        return null;
    }
}