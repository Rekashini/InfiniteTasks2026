using System;

class Program
{
    static void Main()
    {
        UserOperation u = new UserOperation();
        TrainOperation t = new TrainOperation();
        BookingOperation b = new BookingOperation();
        CancellationOperation c = new CancellationOperation();

        Console.WriteLine("===== TRAIN RESERVATION SYSTEM =====");
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Login");

        int first = int.Parse(Console.ReadLine());

        if (first == 1)
        {
            u.CreateUser();
        }

        string role = u.Login();

        if (role == "Admin")
        {
            int ch;

            do
            {
                Console.WriteLine("\n===== ADMIN MENU =====");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Search Train");
                Console.WriteLine("3. Cancel Train");
                Console.WriteLine("4. Exit");

                ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Use SQL or extend TrainOperation.AddTrain if needed");
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
        else if (role == "User")
        {
            int ch;

            do
            {
                Console.WriteLine("\n===== USER MENU =====");
                Console.WriteLine("1. Search Train");
                Console.WriteLine("2. Book Ticket (Max 3 Passengers)");
                Console.WriteLine("3. View Bookings (optional if you added)");
                Console.WriteLine("4. Cancel Ticket");
                Console.WriteLine("5. Exit");

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
                        Console.WriteLine("Add ViewBookings() if needed");
                        break;

                    case 4:
                        c.CancelTicket();
                        break;
                }

            } while (ch != 5);
        }

        Console.WriteLine("Thank you for using the system!");
    }
}