using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem
{
    [Serializable]
    public class HotelRoom: ICloneable
    {
        public enum RoomType {SINGLE, DOUBLE, FAMILY};
        private RoomType roomType;
        private string name;
        private double price;
       


        public string Name { get => name; set => name = value; }
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
        public double Price { get => price; set => price = value; }


        public HotelRoom()
        {
        }

        public HotelRoom(string roomType, string name, double price)
        {
            this.name = name;
            RoomType1 = roomType;
            this.Price = price; 
        }

        public object Clone()
        {
            return this.MemberwiseClone() as HotelRoom;
        }

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
