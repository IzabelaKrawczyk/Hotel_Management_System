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
        private string postalCode;
        
        public Address()
        {

        }

        public Address(string city, string postalCode)
        {
            City = city;
            PostalCode = postalCode;
        }

        public Address(string street, string streetNumber, string flatNumber, string city, string postalCode) : this(street, streetNumber)
        {
            this.flatNumber = flatNumber;
            this.city = city;
            this.postalCode = postalCode;
        }

        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string City { get => city; set => city = value; }
        public string StreetNumber1 { get => streetNumber; set => streetNumber = value; }
        public string Street1 { get => street; set => street = value; }
        public string FlatNumber { get => flatNumber; set => flatNumber = value; }
    }
}
