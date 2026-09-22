using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace HotelOOP
{
    internal class HotelBooking
    {



        public string GuestName { get; set; }


        public int Price = 500;


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }


        public int Days { get; set; }


        public int endDate { get; set; }

        public int GuestPhoneNumber { get; set; }

        public string GuestEmail { get; set; }


        public void PrintInfo()

        {
            Console.WriteLine("Guest: " + GuestName);
            Console.WriteLine("Check In: " + StartDate.ToString());
            Console.WriteLine("Check out: " + EndDate.ToString());
            Console.WriteLine("Nights: " + Days);
            Console.WriteLine("Price: " + TotalPrice() + " KR");
            Console.WriteLine("Phone Number: " + "+46" + GuestPhoneNumber);
            Console.WriteLine("Email: " + GuestEmail);
        }

        public HotelBooking(string guestName, DateTime startDate, int days, int phonenumber, string youremail)
        {
            GuestName = guestName;
             
            StartDate = startDate;
            Days = days;

            EndDate = startDate.AddDays(days);
            GuestPhoneNumber = phonenumber;

            GuestEmail = youremail;
        }


        public int TotalPrice()
        {
            int totalPrice = Price * Days;
            return totalPrice;

        }

        public void Extend(int extranights)
        {
            Days += extranights;
            EndDate = StartDate.AddDays(Days);
        }










    }
}
