using System;
using System.Linq;
using System.Text;

namespace HotelSystem
{
    ///<summary>
    ///Class that represents the address of the clients
    ///</summary>
    [Serializable]
    public class Address
    {
        #region fields
        private string street;
        private string streetNumber;
        private string flatNumber;
        private string city;
        private int postalCode;
        #endregion

        #region properties
        /// <summary>
        /// The street name getter and setter. 
        /// </summary>
        public string Street1
        {
            get => street;
            set
            {
                if (value.Length > 0 && Char.IsUpper(value[0]))
                    street = value;
                else throw new ArgumentException("Wrong name of the street!");
            }
        }

        /// <summary>
        /// The streetNumber getter and setter.
        /// </summary>
        public string StreetNumber1
        {
            get => streetNumber;
            set
            {
                if (value.Length > 0 && value.All(Char.IsLetterOrDigit))
                    streetNumber = value;
                else throw new ArgumentException("Wrong street number!");
            }
        }

        /// <summary>
        /// The flatNumber getter and setter.
        /// </summary>
        public string FlatNumber { get => flatNumber; set => flatNumber = value; }

        /// <summary>
        /// The city getter and setter.
        /// </summary>
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

        /// <summary>
        /// The postalCode getter and setter.
        /// </summary>
        public string PostalCode
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
        #endregion

        #region constructors
        /// <summary>
        /// The parameterless constructor of the address.
        /// </summary>
        public Address()
        {

        }

        /// <summary>
        /// The parameter constructor of the address.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        public Address(string city, string postalCode)
        {
            City = city;
            PostalCode = postalCode;
        }

        /// <summary>
        /// The parameter constructor of the address.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        /// <param name="flatNumber"></param>
        public Address(string city, string postalCode, string street, string streetNumber, string flatNumber) : this(city, postalCode)
        {
            Street1 = street;
            StreetNumber1 = streetNumber;
            FlatNumber = flatNumber;
        }
        #endregion

        /// <summary>
        /// The overridden ToString method
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder myStringBuilder = new StringBuilder("City: " + City + "Postalcode: " + PostalCode.Substring(0, 2) + "-" + PostalCode.Substring(2, 3) + System.Environment.NewLine);
            myStringBuilder.Append("Street: " + Street1 + " " + StreetNumber1 + "flat number: " + FlatNumber);

            return myStringBuilder.ToString();
        }
    }
}
