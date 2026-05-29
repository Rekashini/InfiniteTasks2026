using System;
using System.Data.SqlClient;
using TrainReservationSystem;

class CancellationOperation
{
    DBHandler db = new DBHandler();

    public void CancelTicket()
    {
        SqlConnection con = db.GetConnection();
        con.Open();

        Console.Write("Booking Id: ");
        int bid = int.Parse(Console.ReadLine());

        SqlTransaction tx = con.BeginTransaction();

        try
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT TravelDate,Amount,TrainNo,TravelClass,BookingStatus FROM BookingDetails WHERE BookingId=@b AND UserEmail=@u",
                con, tx);

            cmd.Parameters.AddWithValue("@b", bid);
            cmd.Parameters.AddWithValue("@u", Session.LoggedInUser);

            SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                Console.WriteLine("Invalid Booking");
                dr.Close();
                tx.Rollback();
                return;
            }

            DateTime td = Convert.ToDateTime(dr["TravelDate"]);
            float amt = Convert.ToSingle(dr["Amount"]);
            int train = Convert.ToInt32(dr["TrainNo"]);
            string cls = dr["TravelClass"].ToString();

            dr.Close();

            float refund = amt * 0.7f;

            SqlCommand ins = new SqlCommand(
                "INSERT INTO CancellationDetails VALUES(@b,@r,GETDATE())",
                con, tx);

            ins.Parameters.AddWithValue("@b", bid);
            ins.Parameters.AddWithValue("@r", refund);

            ins.ExecuteNonQuery();

            SqlCommand up1 = new SqlCommand(
                "UPDATE BookingDetails SET BookingStatus='Cancelled' WHERE BookingId=@b",
                con, tx);

            up1.Parameters.AddWithValue("@b", bid);

            up1.ExecuteNonQuery();

            SqlCommand up2 = new SqlCommand(
                "UPDATE TrainClassDetails SET Availability=Availability+1 WHERE TrainNo=@t AND Class=@c",
                con, tx);

            up2.Parameters.AddWithValue("@t", train);
            up2.Parameters.AddWithValue("@c", cls);

            up2.ExecuteNonQuery();

            tx.Commit();

            Console.WriteLine("Cancelled Successfully");
        }
        catch
        {
            tx.Rollback();
            Console.WriteLine("Failed");
        }

        con.Close();
    }
}