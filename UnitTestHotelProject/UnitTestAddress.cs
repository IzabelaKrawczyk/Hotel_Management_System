using HotelSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestHotelProject
{
    /// <summary>
    /// Unit tests of the class Address
    /// </summary>
    [TestClass]
    public class UnitTestAddress
    {
        /// <summary>
        /// The test of the parameter constructor of the address. 
        /// </summary>
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

        /// <summary>
        /// The test of the city setter, that throws ArgumentException when value hasn't only letters.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddressWrongCity()
        {
            _ = new Address
            {
                City = "Kasdhsd?"
            };
        }

        /// <summary>
        /// The test of the postalCode setter, that throws ArgumentException when value hasn't 5 digits not counting the "-".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddressWrongPostalCode()
        {
            _ = new Address
            {
                PostalCode = "45-67"
            };
        }

        /// <summary>
        /// The test of the streetNumber setter, that throws ArgumentException when value hasn't only letters or digits.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddressWrongStreetNumber()
        {
            _ = new Address
            {
                StreetNumber1 = "323mll;/.,."
            };
        }

        /// <summary>
        /// The test of the street setter, that throws ArgumentException when value doesn't start with upper case letter.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddressWrongStreet()
        {
            _ = new Address
            {
                Street1 = "bla bla bla"
            };
        }



    }
}
