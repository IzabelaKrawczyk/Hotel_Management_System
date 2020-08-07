using HotelSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestHotelProject
{
    /// <summary>
    /// Unit tests of the class Reservation
    /// </summary>
    [TestClass]
    public class UnitTestReservation
    {
        /// <summary>
        /// The test of the Reservation parameter constructor.
        /// </summary>
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

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void TestReservationWrongCheckInDate()
        //{
        //    Reservation r = new Reservation();
        //    r.CheckInDate = "19/01/2020";
        //}

        /// <summary>
        /// The test of the checkOutDate setter that throws ArgumentException when the value is earlier than checkInDate. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestReservationWrongCheckOutDate()
        {
            _ = new Reservation
            {
                CheckInDate = "21/01/2020",
                CheckOutDate = "17/01/2020"
            };
        }

    }
}
