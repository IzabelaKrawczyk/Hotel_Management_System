using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace HotelSystem
{
    [Serializable]
    ///<summary>
    ///Class that represents the address of the clients
    ///</summary>
    public class Address
    {
        #region fields
        /// <summary>
        ///Static global id in a purpose to auto increment the address id value.
        /// </summary>
        public static int ID=-1;
        private int AddressID;
        private string street;
        private string streetNumber;
        private string flatNumber;
        private string city;
        private int postalCode;
        #endregion

        #region constructors
        /// <summary>
        ///Parameterless constructor of the address
        /// </summary>
        public Address()
        {   
            ID++;
            AddressID=Interlocked.Increment(ref ID);
        }

        /// <summary>
        ///Constructor of the address with two parameters: city and postal code
        /// </summary>
        /// <param name="city"> string</param>
        /// <param name="postalCode">string</param>
        public Address(string city, string postalCode):this()
        {
            City = city;
            PostalCode = postalCode;
        }

        /// <summary>
        ///Constructor of the address with 5 parameters: city, postal code, street name, street number and flat number
        /// </summary>
        /// <param name="city"> string</param>
        /// <param name="postalCode">string</param>
        /// <param name="street">string</param>
        /// <param name="streetNumber"> string</param>
        /// <param name="flatNumber">string</param>
        public Address(string city, string postalCode, string street, string streetNumber, string flatNumber) : this(city, postalCode)
        {
            Street1 = street;
            StreetNumber1 = streetNumber;
            FlatNumber = flatNumber;
        }
        #endregion

        #region properties

        /// <summary>
        ///Getter and setter of  AddressID
        /// </summary>
        public int AddressID1 { get => AddressID; set => AddressID = value; }

        /// <summary>
        ///Getter and setter of Street
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
        ///Getter and setter of StreetNumber
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
        ///Getter and setter of flatNumber
        /// </summary>
        public string FlatNumber { get => flatNumber; set => flatNumber = value; }

        /// <summary>
        ///Getter and setter of city 
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
        ///Getter and setter of postalCode
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

        /// <summary>
        ///ToString() overridden method
        /// </summary>
        public override string ToString()
        {
            StringBuilder myStringBuilder = new StringBuilder("Id: "+ AddressID1+ "city: " + City + "postal-code: " + PostalCode.Substring(0, 2) + "-" + PostalCode.Substring(2, 3) + System.Environment.NewLine);
            myStringBuilder.Append("street: " + Street1 + " " + StreetNumber1 + "flat number: " + FlatNumber);

            return myStringBuilder.ToString();
        }
    }
}
