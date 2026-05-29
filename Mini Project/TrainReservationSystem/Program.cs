using System;

namespace TrainReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            UserOperation u = new UserOperation();
            TrainOperation t = new TrainOperation();
            BookingOperation b = new BookingOperation();
            CancellationOperation c =
                new CancellationOperation();

            Console.WriteLine("1 Create User");
            Console.WriteLine("2 Login");

            int first = int.Parse(Console.ReadLine());

            if (first == 1)
            {
                u.CreateUser();
            }

            string role = u.Login();

            // ADMIN
            if (role == "Admin")
            {
                int ch;

                do
                {
                    Console.WriteLine("\nADMIN MENU");
                    Console.WriteLine("1 Add Train");
                    Console.WriteLine("2 Search Train");
                    Console.WriteLine("3 Cancel Train");
                    Console.WriteLine("4 Exit");

                    ch = int.Parse(Console.ReadLine());

                    switch (ch)
                    {
                        case 1:
                            t.AddTrain();
                            break;

                        case 2:
                            t.SearchTrain();
                            break;

                        case 3:
                            t.CancelTrain();
                            break;
                    }

                } while (ch != 4);
            }

            // USER
            else if (role == "User")
            {
                int ch;

                do
                {
                    Console.WriteLine("\nUSER MENU");
                    Console.WriteLine("1 Search Train");
                    Console.WriteLine("2 Book Ticket");
                    Console.WriteLine("3 View Booking");
                    Console.WriteLine("4 View Passengers");
                    Console.WriteLine("5 Cancel Ticket");
                    Console.WriteLine("6 View Cancellation");
                    Console.WriteLine("7 Exit");

                    ch = int.Parse(Console.ReadLine());

                    switch (ch)
                    {
                        case 1:
                            t.SearchTrain();
                            break;

                        case 2:
                            b.BookTicket();
                            break;

                        case 3:
                            b.ViewBookings();
                            break;

                        case 4:
                            b.ViewPassengers();
                            break;

                        case 5:
                            c.CancelTicket();
                            break;

                        case 6:
                            c.ViewCancellation();
                            break;
                    }

                } while (ch != 7);
            }
        }
    }
}