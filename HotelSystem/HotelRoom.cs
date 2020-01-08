using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem
{
    [Serializable]
    class HotelRoom: ICloneable
    {
        public enum RoomType { SINGLE, DOUBLE, FAMILY};
        private RoomType roomType;
        private string name;
        private double price;

        public string Name { get => name; set => name = value; }
        internal RoomType RoomType1 { get => roomType; set => roomType = value; }
        public double Price { get => price; set => price = value; }

        public HotelRoom(RoomType roomType, string name, double price)
        {
            this.name = name;
            this.roomType = roomType;
            this.Price = price;
            
        }

        public object Clone()
        {
            return this.MemberwiseClone() as HotelRoom;
        }
    }
}
