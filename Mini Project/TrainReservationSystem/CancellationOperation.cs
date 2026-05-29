using System;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    class CancellationOperation
    {
        DBHandler db = new DBHandler();

        public void CancelTicket()
        {
            SqlConnection con = db.GetConnection();

            Console.Write("Booking Id: ");
            int bid = int.Parse(Console.ReadLine());

            Console.Write("Passenger Name: ");
            string pname = Console.ReadLine();

            con.Open();

            SqlTransaction tx = con.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT TravelDate,
                             Amount,
                             Passengers,
                             TrainNo,
                             TravelClass
                      FROM BookingDetails
                      WHERE BookingId=@b",
                    con, tx);

                cmd.Parameters.AddWithValue("@b", bid);

                SqlDataReader dr = cmd.ExecuteReader();

                DateTime td = DateTime.Now;
                float amount = 0;
                int pass = 0;
                int train = 0;
                string cls = "";

                if (dr.Read())
                {
                    td = Convert.ToDateTime(dr["TravelDate"]);
                    amount = Convert.ToSingle(dr["Amount"]);
                    pass = (int)dr["Passengers"];
                    train = (int)dr["TrainNo"];
                    cls = dr["TravelClass"].ToString();
                }

                dr.Close();

                double days =
                    (td - DateTime.Now).TotalDays;

                float refund = 0;

                if (days >= 3)
                    refund = amount / pass;

                else if (days >= 2)
                    refund = (amount / pass) * 0.7f;

                else
                    refund = 0;

                SqlCommand ins = new SqlCommand(
                    @"INSERT INTO CancellationDetails
                    VALUES(@b,@p,@r,GETDATE())",
                    con, tx);

                ins.Parameters.AddWithValue("@b", bid);
                ins.Parameters.AddWithValue("@p", pname);
                ins.Parameters.AddWithValue("@r", refund);

                ins.ExecuteNonQuery();

                SqlCommand del = new SqlCommand(
                    @"DELETE FROM PassengerDetails
                      WHERE BookingId=@b
                      AND PassengerName=@p",
                    con, tx);

                del.Parameters.AddWithValue("@b", bid);
                del.Parameters.AddWithValue("@p", pname);

                del.ExecuteNonQuery();

                SqlCommand up1 = new SqlCommand(
                    @"UPDATE BookingDetails
                      SET Passengers=Passengers-1
                      WHERE BookingId=@b",
                    con, tx);

                up1.Parameters.AddWithValue("@b", bid);

                up1.ExecuteNonQuery();

                SqlCommand up2 = new SqlCommand(
                    @"UPDATE TrainClassDetails
                      SET Availability=Availability+1
                      WHERE TrainNo=@t
                      AND Class=@c",
                    con, tx);

                up2.Parameters.AddWithValue("@t", train);
                up2.Parameters.AddWithValue("@c", cls);

                up2.ExecuteNonQuery();

                // IF ALL CANCELLED
                SqlCommand chk = new SqlCommand(
                    @"SELECT Passengers
                      FROM BookingDetails
                      WHERE BookingId=@b",
                    con, tx);

                chk.Parameters.AddWithValue("@b", bid);

                int rem =
                    Convert.ToInt32(chk.ExecuteScalar());

                if (rem == 0)
                {
                    SqlCommand st = new SqlCommand(
                        @"UPDATE BookingDetails
                          SET BookingStatus='Cancelled'
                          WHERE BookingId=@b",
                        con, tx);

                    st.Parameters.AddWithValue("@b", bid);

                    st.ExecuteNonQuery();
                }

                tx.Commit();

                Console.WriteLine("Cancelled: " + pname);
                Console.WriteLine("Refund: " + refund);
            }
            catch
            {
                tx.Rollback();
                Console.WriteLine("Cancellation Failed");
            }

            con.Close();
        }

        public void ViewCancellation()
        {
            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM CancellationDetails",
                con);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine();
            Console.WriteLine(
                "CId | BookingId | Passenger | Refund");

            Console.WriteLine("----------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(
                    dr["CId"] + " | " +
                    dr["BookingId"] + " | " +
                    dr["PassengerName"] + " | " +
                    dr["RefundAmount"]);
            }

            con.Close();
        }
    }
}