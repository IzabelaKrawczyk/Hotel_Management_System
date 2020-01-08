using HotelSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HotelSystem
{
    [Serializable]
    public abstract class Client : IEquatable<Client>, ICloneable
    {
        public enum Gender { F, M };

        #region properties
        private string firstName;
        private string lastName;
        private Gender gender;
        private DateTime dataUrodzenia;
        private Address address;
        private string mailAddress;
        private string telNo;
        private HotelRoom hotelRoom;
        private DateTime entryDate;
        private DateTime departureDate;

        #endregion

        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public Gender Gender1 { get => gender; set => gender = value; }
        public string MailAddress { get => mailAddress; set => mailAddress = value; }
        public string TelNo { get => telNo; set => telNo = value; }
        internal HotelRoom HotelRoom { get => hotelRoom; set => hotelRoom = value; }
        public DateTime EntryDate { get => entryDate; set => entryDate = value; }
        public DateTime DepartureDate { get => departureDate; set => departureDate = value; }
        internal Address Address { get => address; set => address = value; }

        #region constructors
        public Client()
        {
            firstName = "";
            lastName = "";
            DataUrodzenia = DateTime.Now;
        }

        public Client(string firstName, string lastName, Gender gender, DateTime dataUrodzenia,Address address, string mailAddress, string telNo)
        {
            this.gender = gender;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dataUrodzenia = dataUrodzenia;
            this.address = address;
            this.mailAddress = mailAddress;
            if(IsDigitsOnly(telNo) && telNo.Length>=6)
            this.TelNo = telNo;
        }

        #endregion

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        public int Wiek()
        {
            return (DateTime.Now.Year - DataUrodzenia.Year);
        }
        public override string ToString()
        {
            return FirstName + " " + LastName + " " + DataUrodzenia + " " + Gender1 + " " + MailAddress + " " + TelNo;
        }

        public bool Equals(Client other)
        {

            if (other == null)
                return false;
            return this.FirstName == other.FirstName && this.LastName == other.LastName && this.DataUrodzenia == other.DataUrodzenia && this.Gender1 == other.Gender1 && this.Address==other.Address;
        }

        public object Clone()
        {
            return this.MemberwiseClone() as Client;
        }
    }

  
}