using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HotelSystem
{
    [Serializable]
#pragma warning disable CS1587 // XML comment is not placed on a valid language element
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Client'
    ///<summary>
    ///Client class that represent the client of the hotel
    ///</summary>
    public class Client : IEquatable<Client>, ICloneable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Client'
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Client.Gender.M'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Client.Gender.F'
        /// <summary>
        /// Types of gender of the client
        /// </summary>
        public enum Gender { F, M };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Client.Gender.F'
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Client.Gender.M'

        #region properties
        private string firstName;
        private string lastName;
        private Gender gender;
        private DateTime dateOfBirth;
        private Address address;
        private string mailAddress;
        private string telNo;



        #endregion
        /// <summary>
        /// Last name of client
        /// </summary>
        public string LastName
        {
            get => lastName;
            set
            {
                if (value.All(Char.IsLetter))
                    lastName = value;
                else throw new ArgumentException("Not valid last name!");
            }

        }
        /// <summary>
        /// First name of client
        /// </summary>
        public string FirstName
        {
            get => firstName;
            set
            {
                if (value.All(Char.IsLetter))
                    firstName = value;
                else throw new ArgumentException("Not valid first name!");
            }
        }
        /// <summary>
        /// Date of birth of client
        /// </summary>
        public string DateOfBirth
        {
            get => dateOfBirth.ToString();

            set
            {
                DateTime d = DateTime.Parse(value);
                if (Age(d) >= 18)
                    dateOfBirth = d;
                else throw new ArgumentException("Client to young to make a reservation.");
            }
        }
        /// <summary>
        /// Client gender
        /// </summary>
        public string Gender1
        {
            get => gender.ToString();
            set
            {
                if (string.Compare(value, "F") == 0)
                    gender = Gender.F;

                else if (string.Compare(value, "M") == 0)
                    gender = Gender.M;

                else throw new ArgumentException("Gender is only F or M.");
            }
        }
        /// <summary>
        /// mail address of client 
        /// </summary>
        public string MailAddress
        {
            get => mailAddress;
            set
            {
                if (new EmailAddressAttribute().IsValid(value))
                    mailAddress = value;
                else throw new FormatException("Mail address is not valid!");
            }

        }
        /// <summary>
        /// Telephone number of client
        /// </summary>
        public string TelNo
        {
            get => telNo;
            set
            {
                if (value.All(Char.IsDigit) && value.Length >= 6)
                    telNo = value;
                else throw new ArgumentException("Wrong telephone number");
            }
        }
        /// <summary>
        /// Address of the client
        /// </summary>
        public Address Address { get => address; set => address = value; }


        #region constructors
        /// <summary>
        /// Client constructor
        /// </summary>
        public Client()
        {
            firstName = "";
            lastName = "";
            DateOfBirth = "01/01/1989";

        }
        /// <summary>
        /// Client parameter constructor
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="gender"></param>
        /// <param name="dateofbirth"></param>
        /// <param name="address"></param>
        /// <param name="mailAddress"></param>
        /// <param name="telNo"></param>
        public Client(string firstName, string lastName, string gender, string dateofbirth, Address address, string mailAddress, string telNo)
        {
            DateOfBirth = dateofbirth;
            Gender1 = gender;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            MailAddress = mailAddress;
            TelNo = telNo;

        }

        #endregion


        /// <summary>
        /// Method that counts the age of client
        /// </summary>
        /// <param name="date"> DateTime</param>
        /// <returns>int age </returns>
        public int Age(DateTime date)
        {
            int age = DateTime.Now.Year - date.Year;
            if (DateTime.Now.DayOfYear < date.DayOfYear)
                age = age - 1;
            return age;
        }
        /// <summary>
        /// Overridden ToString method
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "Client: " + FirstName + " " + LastName + " " + DateOfBirth + " " + Gender1 + " " + MailAddress + " " + TelNo;
        }
        /// <summary>
        /// Method equals that checks if this client is equal to other client 
        /// </summary>
        /// <param name="other"> Client</param>
        /// <returns>true if equals other client is equal to this</returns>
        public bool Equals(Client other)
        {
            if (other == null)
                return false;
            return this.FirstName == other.FirstName && this.LastName == other.LastName && this.DateOfBirth == other.DateOfBirth && this.Gender1 == other.Gender1 && this.Address == other.Address;
        }
        /// <summary>
        /// Clone method of client
        /// </summary>
        /// <returns>object client</returns>
        public object Clone()
        {
            return this.MemberwiseClone() as Client;
        }
    }


}