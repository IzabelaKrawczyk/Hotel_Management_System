using System;
using HotelSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestHotelProject
{
    [TestClass]
    public class UnitTestHotelRoom
    {
        [TestMethod]
        public void TestRoomConstructor()
        {
            HotelRoom h = new HotelRoom("SINGLE", "room", 567.55);
            Assert.AreEqual("SINGLE", h.RoomType1);
            Assert.AreEqual("room", h.Name);
            Assert.AreEqual(567.55, h.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRoomWrongRoomType()
        {
            HotelRoom h = new HotelRoom();
            h.RoomType1 = "one";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRoomWrongRoomPrice()
        {
            HotelRoom h = new HotelRoom();
            h.Price = -12.45;
        }
    }
}
