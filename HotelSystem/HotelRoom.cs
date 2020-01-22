using System;

namespace HotelSystem
{
    [Serializable]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'HotelRoom'
#pragma warning disable CS1587 // XML comment is not placed on a valid language element
    ///<summary>
    ///Class that represent the room of the hotel
    ///</summary>
    public class HotelRoom : ICloneable
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'HotelRoom'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'HotelRoom.RoomType.FAMILY'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'HotelRoom.RoomType.SINGLE'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'HotelRoom.RoomType.DOUBLE'
        /// <summary>
        /// Different types of the hotel room
        /// if it is a single, double, family room
        /// </summary>
        public enum RoomType { SINGLE, DOUBLE, FAMILY };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'HotelRoom.RoomType.DOUBLE'
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'HotelRoom.RoomType.SINGLE'
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'HotelRoom.RoomType.FAMILY'
        private RoomType roomType;
        private string name;
        private double price;


        /// <summary>
        /// Name of the room
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Type of room
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
        /// Price of the room of type double
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

        /// <summary>
        /// Parameterless constructor of the room
        /// </summary>
        public HotelRoom()
        {
        }
        /// <summary>
        /// Constructor of the room
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
        /// <summary>
        /// Method that clones room to object
        /// </summary>
        /// <returns> object </returns>
        public object Clone()
        {
            return this.MemberwiseClone() as HotelRoom;
        }
        /// <summary>
        /// Overridden ToString method 
        /// </summary>
        /// <returns>string room description</returns>
        public override string ToString()
        {
            string value = "Room: ";
            value += Name + " ";
            value += RoomType1 + " ";
            value += Price;
            return value;
        }
    }
}
