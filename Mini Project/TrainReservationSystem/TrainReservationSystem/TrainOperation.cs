using System;
using System.Data.SqlClient;
using TrainReservationSystem;

class TrainOperation
{
    DBHandler db = new DBHandler();

    public void SearchTrain()
    {
        SqlConnection con = db.GetConnection();

        Console.Write("From: ");
        string f = Console.ReadLine();

        Console.Write("To: ");
        string t = Console.ReadLine();

        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM TrainDetails WHERE FromPlace=@f AND ToPlace=@t", con);

        cmd.Parameters.AddWithValue("@f", f);
        cmd.Parameters.AddWithValue("@t", t);

        con.Open();

        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            Console.WriteLine(dr["TrainNo"] + " " + dr["TrainName"] + " " + dr["Status"]);
        }

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