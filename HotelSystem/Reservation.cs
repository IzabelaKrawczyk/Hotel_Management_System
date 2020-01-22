using System;

namespace HotelSystem
{
    [Serializable]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Reservation'
#pragma warning disable CS1587 // XML comment is not placed on a valid language element
    ///<summary>
    ///Class that represents reservation in the hotel
    ///</summary>
    public class Reservation : ICloneable
#pragma warning restore CS1587 // XML comment is not placed on a valid language element
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Reservation'
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
        /// Parameter constructor that sets the reservation
        /// </summary>
        /// <param name="client">client</param>
        /// <param name="room">hotel room </param>
        /// <param name="checkInDate">string check in date</param>
        /// <param name="checkOutDate">string check out date</param>
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
        public string CheckInDate
        {
            get => checkInDate.ToString();
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
        public string CheckOutDate
        {
            get => checkOutDate.ToString();
            set
            {
                DateTime date = DateTime.Parse(value);

                if (date >= checkInDate) checkOutDate = date;
                else throw new ArgumentException("Wrong date");
            }
        }
        /// <summary>
        /// Reservation price (double)
        /// </summary>
        public double ReservationPrice { get => reservationPrice; set => reservationPrice = value; }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Reservation.Room'
        public HotelRoom Room { get => room; set => room = value; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Reservation.Room'
        /// <summary>
        /// Method that counts for how many nights client will be in the hotel 
        /// </summary>
        /// <returns>int number of nights</returns>
        public int HowManyNights()
        {
            TimeSpan difference = checkOutDate - checkInDate;

            return difference.Days;
        }
        /// <summary>
        /// Clone method of the hotel room to object
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
            string value = "Reservation ID: " + ReservationId + "Client: " + Client + System.Environment.NewLine + "Room:  " + Room + " " + System.Environment.NewLine + "Stay details: " + CheckInDate + "- " + CheckOutDate + System.Environment.NewLine;
            value += "Total prize: " + ReservationPrice + System.Environment.NewLine;
            return value;
        }

    }
}
