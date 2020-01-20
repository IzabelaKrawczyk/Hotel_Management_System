using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem
{ 
    [Serializable]
    ///<summary>
    ///Class that represents reservation in the hotel
    ///</summary>
    public class Reservation: ICloneable
    {
        private Client client;
        private HotelRoom room;
        private int reservationId = 1000;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private double reservationPrice;

        /// <summary>
        /// PArameterless reservation constructor that sets the id of reservation
        /// </summary>
        public Reservation()
        {
            reservationId++;
        }
        /// <summary>
        /// Paramter constructor that sets the reservation
        /// </summary>
        /// <param name="client">Client</param>
        /// <param name="room">Room</param>
        /// <param name="checkInDate">string</param>
        /// <param name="checkOutDate">stirng</param>
        public Reservation(Client client, HotelRoom room, string checkInDate, string checkOutDate)
        {
            Client = client;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            reservationId++;
            ReservationPrice = HowManyNights() * room.Price;
        }
        /// <summary>
        /// Client that want to make reservation
        /// </summary>
        public Client Client { get => client; set => client = value; }
        /// <summary>
        /// Id of reservation (int)
        /// </summary>
        public int ReservationId { get => reservationId; }
        /// <summary>
        /// Check-in date of client visit in hotel (string) 
        /// </summary>
        public string CheckInDate { get => checkInDate.ToString();
            set 
            {
                DateTime date = DateTime.Parse(value);
                if (date >= DateTime.Now.AddHours(-20)) checkInDate = date;
                else throw new ArgumentException("Wrong date");
            }
        }
        /// <summary>
        /// Check-out date of client visit in hotel (string)  
        /// </summary>
        public string CheckOutDate { get => checkOutDate.ToString(); 
            set 
            {
                DateTime date = DateTime.Parse(value);

                if (date>= checkInDate) checkOutDate = date;
                else throw new ArgumentException("Wrong date");
            } 
        }
        /// <summary>
        /// Reservation price (double)
        /// </summary>
        public double ReservationPrice { get => reservationPrice; set => reservationPrice = value; }
        public HotelRoom Room { get => room; set => room=value; }
        /// <summary>
        /// Method that counts for how many nights client will be in the hotel 
        /// </summary>
        /// <returns>int number of nights</returns>
        public int HowManyNights()
        {
            TimeSpan difference =checkOutDate- checkInDate;

            return difference.Days;
        }
        /// <summary>
        /// Clone method of the hotelroom to object
        /// </summary>
        /// <returns>object hotel room</returns>
        public object Clone()
        {
            return this.MemberwiseClone() as Reservation;
        }
        /// <summary>
        /// Overridden ToString method 
        /// </summary>
        /// <returns>string description of the reservation</returns>
        public override string ToString()
        {
            string value = "Reservation ID: " +ReservationId + "Client: "+Client+ System.Environment.NewLine+ "Room:  " + Room + " "+System.Environment.NewLine + "Stay details: " + CheckInDate + "- " + CheckOutDate + System.Environment.NewLine;
            value += "Total prize: " + ReservationPrice + System.Environment.NewLine;
            return value;
        }

    }
}
