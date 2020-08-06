using System;
using System.Threading;

namespace HotelSystem
{
    [Serializable]
    ///<summary>
    ///Class that represent the room of the hotel
    ///</summary>
    public class HotelRoom : ICloneable
    {

        /// <summary>
        /// Different types of the hotel room
        /// if it is a single, double, family room
        /// </summary>
        /// <param tag="SINGLE">0</param>
        /// <param tag="DOUBLE">1</param>
        /// <param tag="FAMILY ">2</param>
        public enum RoomType { SINGLE, DOUBLE, FAMILY };

        #region fields
        /// <summary>
        ///Global static id used in creation of incremental roomID.
        /// </summary>
        public static int id;
        private int roomID;
        private string name;
        private RoomType roomType;
        private double price;
        #endregion

        #region constructors
        /// <summary>
        /// Parameterless constructor of the room
        /// </summary>
        public HotelRoom()
        {
            RoomID = Interlocked.Increment(ref id);
        }
        /// <summary>
        /// Constructor of the room
        /// </summary>
        /// <param name="roomType"> string</param>
        /// <param name="name">string</param>
        /// <param name="price">string</param>
        public HotelRoom(string roomType, string name, double price):this()
        {
            Name = name;
            RoomType1 = roomType;
            Price = price;
        }
        #endregion

        #region properties
        /// <summary>
        /// Id of the room
        /// </summary>
        public int RoomID { get => roomID; set => roomID = value; }

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
        #endregion

       
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
            string value = "Room id: "+ RoomID+ " "+ Name + " ";
            value += RoomType1 + " ";
            value += Price;
            return value;
        }
    }
}
