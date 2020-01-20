using System;
using HotelSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestHotelProject
{
    [TestClass]
    public class UnitTestAddress
    {
        [TestMethod]
        public void TestAddresConstructor()
        {
            Address a = new Address("Kraków", "56789", "Mazowiecka", "56A", "133");
            Assert.AreEqual("Kraków", a.City);
            Assert.AreEqual("56789", a.PostalCode);
            Assert.AreEqual("Mazowiecka", a.Street1);
            Assert.AreEqual("56A", a.StreetNumber1);
            Assert.AreEqual("133", a.FlatNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddressWrongCity()
        {
            Address a = new Address();
            a.City = "Kasdhsd?";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddressWrongPostalCode()
        {
            Address a = new Address();
            a.PostalCode = "45-67";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddressWrongStreetNumber()
        {
            Address a = new Address();
            a.StreetNumber1 = "323mll;/.,.";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddressWrongStreet()
        {
            Address a = new Address();
            a.Street1 = "bla bla bla";
        }



    }
}
