using System;

namespace HotelSystem
{
    ///<summary>
    ///The class that represent the room of the hotel.
    ///</summary>
    [Serializable]

    public class HotelRoom : ICloneable

    {
        /// <summary>
        /// The enumeration type that represents different types of the hotel room.
        /// </summary>
        public enum RoomType 
        { 
            /// <summary>room for a person </summary>
            SINGLE,
            /// <summary>room for two people </summary>
            DOUBLE,
            /// <summary>room for a family </summary>
            FAMILY
        };

        #region fields
        private RoomType roomType;
        private string name;
        private double price;
        #endregion

        #region properties
        /// <summary>
        /// The type of room getter and setter.
        /// </summary>
        public string RoomType1
        {
            get => roomType.ToString();
            set
            {
                if (string.Compare(value, "SINGLE") == 0 || string.Compare(value, "single") == 0)
                    roomType = RoomType.SINGLE;
                else if (string.Compare(value, "DOUBLE") == 0 || string.Compare(value, "double") == 0)
                    roomType = RoomType.DOUBLE;
                else if (string.Compare(value, "FAMILY") == 0 || string.Compare(value, "family") == 0)
                    roomType = RoomType.FAMILY;
                else throw new ArgumentException("Wrong room type");
            }
        }

        /// <summary>
        /// The name of the room getter and setter.
        /// </summary>
        public string Name { get => name; set => name = value; }
        
        /// <summary>
        /// The price of the room getter and setter.
        /// </summary>
        public double Price
        {
            get => price;
            set
            {
                if (value > 0.00)
                    price = value;
                else throw new ArgumentException("Nothings for free!");
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// The parameterless constructor of the HotelRoom
        /// </summary>
        public HotelRoom()
        {
        }

        /// <summary>
        /// The parameter constructor of the HotelRoom
        /// </summary>
        /// <param name="roomType"> string</param>
        /// <param name="name">string</param>
        /// <param name="price">string</param>
        public HotelRoom(string roomType, string name, double price)
        {
            Name = name;
            RoomType1 = roomType;
            Price = price;
        }
        #endregion

        /// <summary>
        /// The method that clones room to object.
        /// </summary>
        /// <returns> object </returns>
        public object Clone()
        {
            return this.MemberwiseClone() as HotelRoom;
        }

        /// <summary>
        /// The overridden ToString method. 
        /// </summary>
        /// <returns>string room description</returns>
        public override string ToString()
        {
            string value = "";
            value += Name + " ";
            value += RoomType1 + " ";
            value += Price;
            return value;
        }
    }
}
