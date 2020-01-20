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
    ///<summary>
    ///Client class that represent the client of the hotel
    ///</summary>
    public class Client : IEquatable<Client>, ICloneable
    {
        /// <summary>
        /// Enum type of gender of a client
        /// </summary>
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
        /// <summary>
        /// Lastname of client
        /// </summary>
        public string LastName 
        { 
            get => lastName; 
            set
            {
                if (value.All(Char.IsLetter))
                    lastName = value;
                else throw new ArgumentException("Not valid lastname!");
            }
                
        }
        /// <summary>
        /// Firstname of client
        /// </summary>
        public string FirstName 
        { 
            get => firstName;
            set
            {
                if (value.All(Char.IsLetter))
                    firstName = value;
                else throw new ArgumentException("Not valid firstname!");
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
                DateTime d= DateTime.Parse(value);
                if (Age(d) >= 18) 
                    dateOfBirth = d;
                else throw new ArgumentException("Client to young to make a reservation.");
            }
        }
        /// <summary>
        /// Client gender
        /// </summary>
        public string Gender1 { get => gender.ToString();
            set
            {
                if(string.Compare(value, "F")==0)
                gender = Gender.F;

                else if (string.Compare(value, "M") == 0)
                gender = Gender.M;

                else throw new ArgumentException("Gender is only F or M.");
            }
        }
        /// <summary>
        /// mail addresss of client 
        /// </summary>
        public string MailAddress 
        { 
            get => mailAddress;
            set
            {
                if(value.Contains("@") && value.Contains("."))
                    mailAddress = value;
                else throw new ArgumentException("Mail address is not valid!");
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
        /// Client constuctor
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
        public Client(string firstName, string lastName, string gender, string dateofbirth,Address address, string mailAddress, string telNo)
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
        /// Mathod that counts the age of client
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
            return "Client: "+FirstName + " " + LastName + " " + DateOfBirth + " " + Gender1 + " " + MailAddress + " " + TelNo;
        }
        /// <summary>
        /// Mathod equals that checks if this client is equal to other client 
        /// </summary>
        /// <param name="other"> Client</param>
        /// <returns>bool true if equals</returns>
        public bool Equals(Client other)
        {
            if (other == null)
                return false;
            return this.FirstName == other.FirstName && this.LastName == other.LastName && this.DateOfBirth == other.DateOfBirth && this.Gender1 == other.Gender1 && this.Address==other.Address;
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