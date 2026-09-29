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

            Console.Clear();

            Department hotel = new Department("The OOP Hotel");
            Department frontDesk = new Department("Front Desk");
            Department housekeeping = new Department("Housekeeping");

            hotel.AddSubdepartment(frontDesk);
            hotel.AddSubdepartment(housekeeping);

            bool run = true;

            while (run)
            {
                Console.WriteLine("Welcome to THE OOP Hotel...");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Make a booking.");
                Console.WriteLine("2. Change Booking");
                Console.WriteLine("3. Add a new employee");
                Console.WriteLine("4. Fire a employee");
                Console.WriteLine("5.Exit");
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
                            AddEmployee();
                            break;

                        case 4:
                            FireEmployee(frontDesk);
                            break;

                        case 5:
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

        public static void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("Add a new employee: ");
            Console.Write("What´s the employee name?: ");
            string name = Console.ReadLine();
            Department frontDesk = new Department("Front Desk");

            Console.WriteLine("What´s the employee job title?: ");
            Console.WriteLine("Job title options: Front Desk, Housekeeper, Manager");
            string jobTitle = Console.ReadLine();

            switch (jobTitle)
            {
                case "Front Desk":
                    frontDesk.AddEmployee(new Employee { Name = name, JobTitle = "Receptionist" });

                    break;
                case "Housekeeper":
                    frontDesk.AddEmployee(new Employee { Name = name, JobTitle = "Housekeeper" });
                    break;
                case "Manager":
                    frontDesk.AddEmployee(new Employee { Name = name, JobTitle = "Manager" });
                    break;
                default:
                    Console.WriteLine("Invalid job title.");
                    return;
            }

            frontDesk.PrintOrganizationChart();
        }

        public static void FireEmployee(Department frontDesk)
        {
            Console.Clear();
            Console.WriteLine("Fire an employee: ");
            Console.Write("What´s the employee name?: ");
            string name = Console.ReadLine();
            frontDesk.RemoveEmployee(new Employee { Name = name });
            Console.WriteLine($"Employee {name} has been fired.");
        }
    }
}
