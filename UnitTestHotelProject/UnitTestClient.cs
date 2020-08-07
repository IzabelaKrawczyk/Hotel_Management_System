using HotelSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestHotelProject
{
    /// <summary>
    /// Tests of the class client
    /// </summary>
    [TestClass]
    public class ClientUnitTest
    {   
        /// <summary>
        /// The test of the parameter constructor of the client class
        /// </summary>
        [TestMethod]
        public void TestClientConstructorParameter()
        {
            Address address = new Address("Kraków", "30234");
            Client c = new Client("A", "L", "M", "15/03/1999", address, "yaay@onet.pl", "600000000");
            Assert.AreEqual("A", c.FirstName);
            Assert.AreEqual("L", c.LastName);
            Assert.AreEqual("M", c.Gender1);
            Assert.AreEqual(DateTime.Parse("15/03/1999"), DateTime.Parse(c.DateOfBirth));
            Assert.AreEqual(address, c.Address);
            Assert.AreEqual("yaay@onet.pl", c.MailAddress);
            Assert.AreEqual("600000000", c.TelNo);

        }

        /// <summary>
        /// The test of the telephone number setter, that throws AgrumentException when variable hasn't only digits.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongTelNo()
        {
            _ = new Client
            {
                TelNo = "ala"
            };
        }

        /// <summary>
        /// The test of the dateOfBirth setter, that throws ArgumentException when client isn't 18.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongDateOFBirth()
        {
            _ = new Client
            {
                DateOfBirth = "19.01.2020"
            };
        }

        /// <summary>
        /// The test of the firstName setter, that throws ArgumentException when value hasn't only letters. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongFirstName()
        {
            _ = new Client
            {
                FirstName = "12938024"
            };
        }

        /// <summary>
        /// The test of the lastName setter, that throws ArgumentException when value hasn't only letters. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongLastName()
        {
            _ = new Client
            {
                LastName = "JJ2435"
            };
        }

        /// <summary>
        /// The test of the gender setter, that throws ArgumentException when value is not "F" or "M".
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongGender()
        {
            _ = new Client
            {
                Gender1 = "K"
            };
        }

        /// <summary>
        /// The test of the emailAddress setter that throws FormatException when value has wrong format. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestClientWrongmailAddress()
        {
            _ = new Client
            {
                MailAddress = "test.pl"
            };
        }

    }
}
