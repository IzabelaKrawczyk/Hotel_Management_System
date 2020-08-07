using HotelSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestHotelProject
{
    /// <summary>
    /// Unit tests of the hotel class.
    /// </summary>
    [TestClass]
    public class UnitTestHotel
    {
        /// <summary>
        ///The test of the parameter constructor of the hotel.
        /// </summary>
        [TestMethod]
        public void TestHotelConstructor()
        {
            Client c1 = new Client("Izabela", "Krawczyk", "F", "16.06.1996", new Address("Kraków", "30456", "W. Budryka", "9", "427"), "iza@gmail.com", "000000000");
            Client c2 = new Client("Anna", "Nowak", "F", "12.12.2000", new Address("Warszawa", "10-564", "J. Piłsudzkiego", "12D", "87"), "annanowak@wp.pl", "987654321");

            HotelRoom a1 = new HotelRoom("SINGLE", "SingleRoom1", 150.0);
            HotelRoom a2 = new HotelRoom("DOUBLE", "DoubleRoom1", 300.0);
            HotelRoom a3 = new HotelRoom("FAMILY", "FamilyRoom1", 500.0);

            List<Client> clientList = new List<Client>
            {
                c1,
                c2
            };

            List<HotelRoom> roomList = new List<HotelRoom>
            {
                a1,
                a2,
                a3
            };
            Hotel h = new Hotel(roomList)
            {
                ClientList = clientList
            };

            for (int i = 0; i < 3; i++)
                Assert.AreEqual(roomList[i], h.RoomList[i]);
            for (int i = 0; i < 2; i++)
                Assert.AreEqual(clientList[i], h.ClientList[i]);
            Assert.AreEqual(3, h.RoomsNumber);
            Assert.AreEqual(0, h.ReservationsNumber);
        }

        /// <summary>
        /// The test of the AddReservation method. 
        /// </summary>
        [TestMethod]
        public void TestHotelAddReservation()
        {
            Client c1 = new Client("Izabela", "Krawczyk", "F", "16.06.1996", new Address("Kraków", "30456", "W. Budryka", "9", "427"), "iza@gmail.com", "000000000");
            Client c2 = new Client("Anna", "Nowak", "F", "12.12.2000", new Address("Warszawa", "10-564", "J. Piłsudzkiego", "12D", "87"), "annanowak@wp.pl", "987654321");

            HotelRoom a1 = new HotelRoom("SINGLE", "SingleRoom1", 150.0);
            HotelRoom a2 = new HotelRoom("DOUBLE", "DoubleRoom1", 300.0);
            HotelRoom a3 = new HotelRoom("FAMILY", "FamilyRoom1", 500.0);

            List<Client> clientList = new List<Client>
            {
                c1,
                c2
            };

            List<HotelRoom> roomList = new List<HotelRoom>
            {
                a1,
                a2,
                a3
            };
            Hotel h = new Hotel(roomList)
            {
                ClientList = clientList
            };

            Address address = new Address("Kraków", "30234");
            Client c = new Client("A", "L", "M", "15/03/1999", address, "yaay@onet.pl", "600000000");
            Reservation r = new Reservation(c, a1, "24.01.2020", "25.01.2020");
            Reservation r1 = new Reservation(c2, a1, "22.01.2020", "23.01.2020");
            h.AddReservation(r);
            h.AddReservation(c2, a1, "22.01.2020", "23.01.2020");
            Assert.AreEqual(h.ReservationList[0].Client, r.Client);
            Assert.AreEqual(h.ReservationList[0].Room, r.Room);
            Assert.AreEqual(h.ReservationList[0].ReservationPrice, r.ReservationPrice);

            Assert.AreEqual(h.ReservationList[1].Client, r1.Client);
            Assert.AreEqual(h.ReservationList[1].Room, r1.Room);
            Assert.AreEqual(h.ReservationList[1].ReservationPrice, r1.ReservationPrice);
        }

    }
}
