using System;
using HotelSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestHotelProject
{
    [TestClass]
    public class ClientUnitTest
    {
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongTelNo()
        {
            Client c= new Client();
            c.TelNo = "ala";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongDateOFBirth()
        {
            Client c = new Client();
            c.DateOfBirth = "19.01.2020";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongFirstName()
        {
            Client c = new Client();
            c.FirstName = "12938024";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongLastName()
        {
            Client c = new Client();
            c.LastName = "JJ2435";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongGender()
        {
            Client c = new Client();
            c.Gender1 = "K";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestClientWrongmailAddress()
        {
            Client c = new Client();
            c.MailAddress = "test.pl";
        }

    }
}
