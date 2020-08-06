using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace HotelSystem
{
    class Program
    {
        static void Main()
        {
            Address address = new Address("Kraków", "30456", "W. Budryka", "9", "427");
            Address address1 = new Address("Warszawa", "10564", "J. Piłsudzkiego", "12D", "87");
            _ = new Address("Wrocław", "20089");

            Client c1 = new Client("Izabela", "Krawczyk", "F", "16.06.1996", address, "iza@gmail.com", "000000000");
            Client c2 = new Client("Anna", "Nowak", "F", "12.12.2000", address1, "annanowak@wp.pl", "987654321");
            Client c3 = new Client("Jan", "Kowalski", "M", "01/01/1987", address, "jankowalski@onet.pl", "111111111");
            Client c4 = new Client("Izabela", "Krawczyk", "F", "16.06.1996", address, "izakrawczyk@gmail.com", "100000000");

            HotelRoom a1 = new HotelRoom("SINGLE", "SingleRoom1", 150.0);
            HotelRoom a2 = new HotelRoom("DOUBLE", "DoubleRoom1", 300.0);
            HotelRoom a3 = new HotelRoom("FAMILY", "FamilyRoom1", 500.0);
            HotelRoom a4 = new HotelRoom("SINGLE", "SingleRoom2", 150.0);
            HotelRoom a5 = new HotelRoom("DOUBLE", "DoubleRoom2", 300.0);
            HotelRoom a6 = new HotelRoom("SINGLE", "SingleRoom3", 150.0);
            HotelRoom a7 = new HotelRoom("SINGLE", "SingleRoom4", 150.0);
            HotelRoom a8 = new HotelRoom("DOUBLE", "DoubleRoom3", 300.0);
            HotelRoom a9 = new HotelRoom("FAMILY", "FamilyRoom2", 500.0);

            List<HotelRoom> rooms = new List<HotelRoom>
            {
                a1,
                a2,
                a3,
                a4,
                a5,
                a6,
                a7,
                a8,
                a9
            };



            Hotel hotel = new Hotel(rooms);
            hotel.AddReservation(c1, a1, "11.01.2020", "13.01.2020");
            Console.WriteLine(hotel);

            hotel.AddReservation(c2, a2, "14.01.2020", "16.01.2020");
            hotel.AddReservation(c4, a3, "17.01.2020", "18.01.2020");

            Hotel.WriteXML("hotel.xml", hotel);
            _ = new Hotel();
            Hotel h1 = Hotel.ReadXML("hotel.xml");

            for (int i = 0; i < h1.RoomList.Count; i++)
                Console.WriteLine(h1.RoomList[i]);

            for (int i = 0; i < 3; i++)
                Console.WriteLine(hotel.ReservationList[i]);


            Console.ReadKey();



        }
    }
}
