using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem
{
    [Serializable]
    ///<summary>
    ///Class that represent the room of the hotel
    ///</summary>
    public class HotelRoom: ICloneable
    {
        /// <summary>
        /// enum that represent room type of room
        /// if it is a single, double, family room
        /// </summary>
        public enum RoomType { SINGLE, DOUBLE, FAMILY };
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
        public string RoomType1 { get => roomType.ToString();
            set 
            {
                if (string.Compare(value,"SINGLE")==0 || string.Compare(value,"single")==0)
                    roomType = RoomType.SINGLE;
                else if (string.Compare(value,"DOUBLE")==0|| string.Compare(value,"double")==0)
                    roomType = RoomType.DOUBLE;
                else if (string.Compare(value,"FAMILY")==0|| string.Compare(value,"family")==0)
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
        /// Parameterless contructor of the room
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
