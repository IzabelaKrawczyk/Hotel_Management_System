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
    public class Client : IEquatable<Client>, ICloneable
    {
        public enum Gender {F, M};

        #region properties
        private string firstName;
        private string lastName;
        private Gender gender;
        private DateTime dateOfBirth;
        private Address address;
        private string mailAddress;
        private string telNo;

        

        #endregion

        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string DateOfBirth
        { 
            get => dateOfBirth.ToString();

            set 
            {
                dateOfBirth = DateTime.Parse(value); 
            }
        }
        public string Gender1 { get => gender.ToString();
            set
            {
                if(string.Compare(value, "F")==0 || string.Compare(value, "Female") == 0)
                gender = Gender.F;

                else if (string.Compare(value, "M") == 0 || string.Compare(value, "Male") == 0)
                gender = Gender.M;

                else throw new ArgumentException("Gender is only F or M");
            }
        }

        public string MailAddress { get => mailAddress; set => mailAddress = value; }
        public string TelNo { get => telNo; set => telNo = value; }
        public Address Address { get => address; set => address = value; }


        #region constructors

        public Client()
        {
            firstName = "";
            lastName = "";
            DateOfBirth = DateTime.Now.ToString();
            
        }

        public Client(string firstName, string lastName, string gender, string dateofbirth,Address address, string mailAddress, string telNo)
        {
            DateOfBirth = dateofbirth;
            if (Age() < 18) throw new Exception("Client to young to make a reservation.");
            Gender1 = gender;
            this.firstName = firstName;
            this.lastName = lastName;
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

        public int Age()
        { 
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;
            return age;
        }
        public override string ToString()
        {
            return "Client: "+FirstName + " " + LastName + " " + DateOfBirth + " " + Gender1 + " " + MailAddress + " " + TelNo;
        }

        public bool Equals(Client other)
        {
            if (other == null)
                return false;
            return this.FirstName == other.FirstName && this.LastName == other.LastName && this.DateOfBirth == other.DateOfBirth && this.Gender1 == other.Gender1 && this.Address==other.Address;
        }

        public object Clone()
        {
            return this.MemberwiseClone() as Client;
        }
    }

  
}