using HotelSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestHotelProject
{
    /// <summary>
    /// Unit tests of the HotelRoom class.
    /// </summary>
    [TestClass]
    public class UnitTestHotelRoom
    {
        /// <summary>
        /// The test of the HotelRoom parameter constructor.
        /// </summary>
        [TestMethod]
        public void TestRoomConstructor()
        {
            HotelRoom h = new HotelRoom("SINGLE", "room", 567.55);
            Assert.AreEqual("SINGLE", h.RoomType1);
            Assert.AreEqual("room", h.Name);
            Assert.AreEqual(567.55, h.Price);
        }

        /// <summary>
        /// The test of the roomType setter, that throws ArgumentException when the value is different from "SINGLE", "DOUBLE", and "FAMILY".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRoomWrongRoomType()
        {
            _ = new HotelRoom
            {
                RoomType1 = "one"
            };
        }

        /// <summary>
        /// The test of the price setter that throws ArgumentException when value is negative.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRoomWrongRoomPrice()
        {
            _ = new HotelRoom
            {
                Price = -12.45
            };
        }
    }
}
