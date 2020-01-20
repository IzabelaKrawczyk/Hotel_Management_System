using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem
{
    [Serializable]
    ///<summary>
    ///Class that represents the address of the clients
    ///</summary>
    public class Address
    {
        private string street;
        private string streetNumber;
        private string flatNumber;
        private string city;
        private int postalCode;
        
        public Address()
        {

        }

        public Address(string city, string postalCode)
        {
            City = city;
            PostalCode = postalCode;
        }

        public Address(string city, string postalCode, string street, string streetNumber, string flatNumber):this(city,postalCode)
        {
            Street1 = street;
            StreetNumber1 = streetNumber;
            FlatNumber = flatNumber;
        }

        public string PostalCode { 
            get => postalCode.ToString();
            set
            {
                string postal= string.Concat(value.Where((c) => c != '-'));
                if (postal.Length == 5 && postal.All(Char.IsDigit))
                    postalCode = Int32.Parse(postal);
                else throw new ArgumentException("Wrong postal code!");
            }
        }
        public string City 
        { 
            get => city;
            set
            {
                if (value.All(Char.IsLetter) && Char.IsUpper(value[0]))
                    city = value;
                else throw new ArgumentException("Wrong city name!");
            }
        }
        public string StreetNumber1 
        { 
            get => streetNumber; 
            set
            {
                if (!value.Equals("") && value.All(Char.IsLetterOrDigit))
                    streetNumber = value;
                else throw new ArgumentException("Wrong street number!");
            }

        }
        public string Street1 
        { 
            get => street;
            set
            {
                if (!value.Equals("") && Char.IsUpper(value[0]))
                    street = value;
                else throw new ArgumentException("Wrong name of the street!");
            }
 
        }
        public string FlatNumber { get => flatNumber; set => flatNumber = value; }

        public override string ToString()
        {
            StringBuilder myStringBuilder = new StringBuilder("City: " + City + "Postalcode: " + PostalCode.Substring(0, 2) + "-" + PostalCode.Substring(2, 3) + System.Environment.NewLine);
            myStringBuilder.Append("Street: " + Street1 + " " + StreetNumber1 + "flat number: " + FlatNumber);

            return myStringBuilder.ToString();
        }
    }
}
