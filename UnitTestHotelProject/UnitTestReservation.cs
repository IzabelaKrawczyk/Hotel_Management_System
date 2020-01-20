using System;
using HotelSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestHotelProject
{
    [TestClass]
    public class UnitTestReservation
    {
        [TestMethod]
        public void TestReservationcConstructor()
        {
            Reservation r = new Reservation();
            Assert.AreEqual(1001, r.ReservationId);    
        }

        [TestMethod]
        public void TestReservationcParameterConstructor()
        {
            Address address = new Address("Kraków", "30234");
            HotelRoom h = new HotelRoom("SINGLE", "room", 567.55);
            Client c = new Client("A", "L", "M", "15/03/1999", address, "yaay@onet.pl", "600000000");
            Reservation r = new Reservation(c, h, "24.01.2020", "25.01.2020");
            Assert.AreEqual(c, r.Client);
            Assert.AreEqual(h, r.Room);
            Assert.AreEqual(DateTime.Parse("24.01.2020"), DateTime.Parse(r.CheckInDate));
            Assert.AreEqual(DateTime.Parse("25.01.2020"), DateTime.Parse(r.CheckOutDate));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestReservationWrongCheckInDate()
        {
            Reservation r= new Reservation();
            r.CheckInDate = "19/01/2020";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestReservationWrongCheckOutDate()
        {
            Reservation r = new Reservation();
            r.CheckInDate = "21/01/2020";
            r.CheckOutDate = "17/01/2020";
        }

    }
}
