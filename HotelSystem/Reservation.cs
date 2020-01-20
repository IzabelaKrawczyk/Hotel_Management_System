using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem
{ 
    [Serializable]
    public class Reservation: ICloneable
    {
        private Client client;
        private HotelRoom room;
        private int reservationId = 1000;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private double reservationPrice;

        public Reservation()
        {
            reservationId++;
        }

        public Reservation(Client client, HotelRoom room, string checkInDate, string checkOutDate)
        {
            this.Client = client;
            this.Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            reservationId++;
            ReservationPrice = HowManyNights() * room.Price;
        }

        public Client Client { get => client; set => client = value; }
        public int ReservationId { get => reservationId; }
        public string CheckInDate { get => checkInDate.ToString();
            set 
            {
                DateTime date = DateTime.Parse(value);
                if (date >= DateTime.Now.AddHours(-20.0)) checkInDate = date;
                else throw new ArgumentException("Wrong date");
            }
        }
        public string CheckOutDate { get => checkOutDate.ToString(); 
            set 
            {
                DateTime date = DateTime.Parse(value);

                if (date >= checkInDate) checkOutDate = date;
                else throw new ArgumentException("Wrong date");
            } 
        }

        public double ReservationPrice { get => reservationPrice; set => reservationPrice = value; }
        public HotelRoom Room { get => room; set => room=value; }

        public int HowManyNights()
        {
            TimeSpan difference =checkOutDate- checkInDate;

            return difference.Days;
        }

        public object Clone()
        {
            return this.MemberwiseClone() as Reservation;
        }

        public override string ToString()
        {
            string value = "Reservation ID: " +ReservationId + "Client: "+Client+ System.Environment.NewLine+ "Room:  " + Room + " "+System.Environment.NewLine + "Stay details: " + CheckInDate + "- " + CheckOutDate + System.Environment.NewLine;
            value += "Total prize: " + ReservationPrice + System.Environment.NewLine;
            return value;
        }

    }
}
