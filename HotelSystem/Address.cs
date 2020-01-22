using System;
using System.Linq;
using System.Text;

namespace HotelSystem
{
    [Serializable]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Address'
#pragma warning disable CS1587 // XML comment is not placed on a valid language element
    ///<summary>
    ///Class that represents the address of the clients
    ///</summary>
    public class Address
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Address'
    {
        private string street;
        private string streetNumber;
        private string flatNumber;
        private string city;
        private int postalCode;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Address.Address()'
        public Address()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Address.Address()'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Address.Address(string, string)'
        public Address(string city, string postalCode)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Address.Address(string, string)'
        {
            City = city;
            PostalCode = postalCode;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Address.Address(string, string, string, string, string)'
        public Address(string city, string postalCode, string street, string streetNumber, string flatNumber) : this(city, postalCode)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Address.Address(string, string, string, string, string)'
        {
            Street1 = street;
            StreetNumber1 = streetNumber;
            FlatNumber = flatNumber;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Address.PostalCode'
        public string PostalCode
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Address.PostalCode'
        {
            get => postalCode.ToString();
            set
            {
                string postal = string.Concat(value.Where((c) => c != '-'));
                if (postal.Length == 5 && postal.All(Char.IsDigit))
                    postalCode = Int32.Parse(postal);
                else throw new ArgumentException("Wrong postal code!");
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Address.City'
        public string City
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Address.City'
        {
            get => city;
            set
            {
                if (value.All(Char.IsLetter) && Char.IsUpper(value[0]))
                    city = value;
                else throw new ArgumentException("Wrong city name!");
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Address.StreetNumber1'
        public string StreetNumber1
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Address.StreetNumber1'
        {
            get => streetNumber;
            set
            {
                if (value.Length>0 && value.All(Char.IsLetterOrDigit))
                    streetNumber = value;
                else throw new ArgumentException("Wrong street number!");
            }

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Address.Street1'
        public string Street1
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Address.Street1'
        {
            get => street;
            set
            {
                if (value.Length>0 && Char.IsUpper(value[0]))
                    street = value;
                else throw new ArgumentException("Wrong name of the street!");
            }

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Address.FlatNumber'
        public string FlatNumber { get => flatNumber; set => flatNumber = value; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Address.FlatNumber'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Address.ToString()'
        public override string ToString()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Address.ToString()'
        {
            StringBuilder myStringBuilder = new StringBuilder("City: " + City + "Postalcode: " + PostalCode.Substring(0, 2) + "-" + PostalCode.Substring(2, 3) + System.Environment.NewLine);
            myStringBuilder.Append("Street: " + Street1 + " " + StreetNumber1 + "flat number: " + FlatNumber);

            return myStringBuilder.ToString();
        }
    }
}
