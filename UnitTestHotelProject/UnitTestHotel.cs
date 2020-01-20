using System;
using System.Collections.Generic;
using HotelSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestHotelProject
{
    [TestClass]
    public class UnitTestHotel
    {
 


        

        [TestMethod]
        public void TestHotelConstructor()
        {
            Client c1 = new Client("Izabela", "Krawczyk", "F", "16.06.1996", new Address("Kraków", "30456", "W. Budryka", "9", "427"), "iza@gmail.com", "000000000");
            Client c2 = new Client("Anna", "Nowak", "F", "12.12.2000", new Address("Warszawa", "10-564", "J. Piłsudzkiego", "12D", "87"), "annanowak@wp.pl", "987654321");

            HotelRoom a1 = new HotelRoom("SINGLE", "SingleRoom1", 150.0);
            HotelRoom a2 = new HotelRoom("DOUBLE", "DoubleRoom1", 300.0);
            HotelRoom a3 = new HotelRoom("FAMILY", "FamilyRoom1", 500.0);

            List<Client> clientList = new List<Client>();
            clientList.Add(c1);
            clientList.Add(c2);

            List<HotelRoom> roomList = new List<HotelRoom>();
            roomList.Add(a1);
            roomList.Add(a2);
            roomList.Add(a3);
            Hotel h = new Hotel(roomList);
            h.ClientList = clientList;

            for (int i=0; i<3;i++)
                Assert.AreEqual(roomList[i], h.RoomList[i]);
            for (int i = 0; i < 2; i++)
                Assert.AreEqual(clientList[i], h.ClientList[i]);
            Assert.AreEqual(3, h.RoomsNumber);
            Assert.AreEqual(0, h.ReservationsNumber);
        }

        [TestMethod]
        public void TestHotelAddReservation()
        {
            Client c1 = new Client("Izabela", "Krawczyk", "F", "16.06.1996", new Address("Kraków", "30456", "W. Budryka", "9", "427"), "iza@gmail.com", "000000000");
            Client c2 = new Client("Anna", "Nowak", "F", "12.12.2000", new Address("Warszawa", "10-564", "J. Piłsudzkiego", "12D", "87"), "annanowak@wp.pl", "987654321");

            HotelRoom a1 = new HotelRoom("SINGLE", "SingleRoom1", 150.0);
            HotelRoom a2 = new HotelRoom("DOUBLE", "DoubleRoom1", 300.0);
            HotelRoom a3 = new HotelRoom("FAMILY", "FamilyRoom1", 500.0);

            List<Client> clientList = new List<Client>();
            clientList.Add(c1);
            clientList.Add(c2);

            List<HotelRoom> roomList = new List<HotelRoom>();
            roomList.Add(a1);
            roomList.Add(a2);
            roomList.Add(a3);
            Hotel h = new Hotel(roomList);
            h.ClientList = clientList;

            Address address = new Address("Kraków", "30234");
            Client c = new Client("A", "L", "M", "15/03/1999", address, "yaay@onet.pl", "600000000");
            Reservation r = new Reservation(c, a1, "24.01.2020", "25.01.2020");
            Reservation r1=new Reservation(c2, a1, "22.01.2020", "23.01.2020");
            h.AddReservation(r);
            h.AddReservation(c2, a1, "22.01.2020", "23.01.2020");
            Assert.AreEqual(h.ReservationList[0].ToString(), r.ToString());
            Assert.AreEqual(h.ReservationList[1].ToString(), r1.ToString());

            
        }

    } 
}
