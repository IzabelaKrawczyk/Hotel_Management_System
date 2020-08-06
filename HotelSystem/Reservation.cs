using System;
using System.Threading;

namespace HotelSystem
{
    [Serializable]
    ///<summary>
    ///Class that represents reservation in the hotel
    ///</summary>
    public class Reservation : ICloneable

    {
        #region fields
        ///<summary>
        ///Public static id used in creating incremental reservationId
        ///</summary>
        public static int Id;
        private int reservationId;
        private Client client;
        private HotelRoom room;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private double reservationPrice;
        #endregion

        #region constructors
        /// <summary>
        /// PArameterless reservation constructor that sets the id of reservation
        /// </summary>
        public Reservation()
        {
            Id++;
            ReservationId = Interlocked.Increment(ref Id);
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
            Id++;
            ReservationId = Interlocked.Increment(ref Id);
            Client = client;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            ReservationPrice = HowManyNights() * room.Price;
        }
        #endregion

        #region properties
        /// <summary>
        /// reservation?Id getter ad setter
        /// </summary>
        public int ReservationId { get => reservationId; set => reservationId = value; }

        /// <summary>
        /// Client getter and setter
        /// </summary>
        public Client Client { get => client; set => client = value; }

        /// <summary>
        /// room getter and setter
        /// </summary>
        public HotelRoom Room { get => room; set => room = value; }

        /// <summary>
        /// checkInDate getter and setter 
        /// </summary>
        public string CheckInDate
        {
            get => checkInDate.ToString();
            set
            {
                DateTime date = DateTime.Parse(value);
                checkInDate = date;
                //if (date >= DateTime.Now.AddDays(-1)) checkInDate = date;
                //else throw new ArgumentException("Wrong date");
            }
        }

        /// <summary>
        ///checkOutDate getter and setter 
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
        /// reservation getter and setter
        /// </summary>
        public double ReservationPrice { get => reservationPrice; set => reservationPrice = value; }
        #endregion

        #region methods
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
            string value = "Reservation ID: " + ReservationId + ", " + Client + System.Environment.NewLine  
                            + Room + " " + System.Environment.NewLine 
                            + "Stay details: " + CheckInDate + "- " + CheckOutDate + System.Environment.NewLine
                            + "Total prize: " + ReservationPrice + System.Environment.NewLine;
            return value;
        }
        #endregion
    }
}
