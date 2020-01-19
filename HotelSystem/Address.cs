using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem
{
    [Serializable]
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
            this.street = street;
            this.streetNumber = streetNumber;
        }

        public string PostalCode { 
            get => postalCode.ToString();
            set
            {
                 postalCode = Int32.Parse(value); 
            }
        }
        public string City { get => city; set => city = value; }
        public string StreetNumber1 { get => streetNumber; set => streetNumber = value; }
        public string Street1 { get => street; set => street = value; }
        public string FlatNumber { get => flatNumber; set => flatNumber = value; }

        public override string ToString()
        {
            StringBuilder myStringBuilder = new StringBuilder("City: " + City + "Postalcode: " + PostalCode.Substring(0, 2) + "-" + PostalCode.Substring(2, 3) + System.Environment.NewLine);
            myStringBuilder.Append("Street: " + Street1 + " " + StreetNumber1 + "flat number: " + FlatNumber);

            return myStringBuilder.ToString();
        }
    }
}
