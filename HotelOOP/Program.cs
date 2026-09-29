using System.ComponentModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using NetCoreAudio;

namespace HotelOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<HotelBooking> totalguest = new List<HotelBooking>();

            bool run = true;

            while (run)
            {
                Console.WriteLine("Welcome to THE OOP Hotel...");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Make a booking.");
                Console.WriteLine("2. Change Booking");
                Console.WriteLine("3.Exit");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            BookingRequest(totalguest);

                            break;

                        case 2:
                            ChangeBooking(totalguest);

                            break;

                        case 3:
                            Environment.Exit(1);
                            break;
                    }
                }
            }
        }

        public static void BookingRequest(List<HotelBooking> totalguest)
        {
            Console.Clear();
            Console.WriteLine("New Booking: ");
            Console.Write("What´s your name?: ");
            string name = Console.ReadLine();
            Console.Write("What´s your phone number?: ");

            int phonenumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("What is your email address?");

            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name, idiot.Retry.");
                return;
            }

            Console.Write("How many nights?: ");

            if (int.TryParse(Console.ReadLine(), out int nights) && nights > 0)
            {
                HotelBooking info = new HotelBooking(
                    name,
                    DateTime.Now,
                    nights,
                    phonenumber,
                    email
                );

                info.PrintInfo();

                totalguest.Add(info);
            }
            else
            {
                Console.WriteLine("Please enter a positive number.");
            }
        }

        public static void ChangeBooking(List<HotelBooking> bookings)
        {
            Console.Clear();

            Console.Write("What is your name?: ");
            string name = Console.ReadLine();

            foreach (HotelBooking booking in bookings)
            {
                if (booking.Guest.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Add how many nights?: ");
                    if (int.TryParse(Console.ReadLine(), out int nights) && nights > 0)
                    {
                        booking.Extend(nights);
                        booking.PrintInfo();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a positive number.");
                    }

                    return;
                }
            }

            Console.WriteLine("No booking found with that name.");
        }
    }
}
