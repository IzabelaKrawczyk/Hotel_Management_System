using System;
using System.Collections.Generic;
using System.Threading;

namespace HotelSystem
{
    ///<summary>
    ///Reservation class that represents reservation in the hotel
    ///</summary>
    [Serializable]
    public class Reservation : ICloneable
    {

        #region fields
        ///<summary>
        ///The static int nextID to set auto incremental reservation id.
        ///</summary>
        public static int nextID;
        private static readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        private static readonly SortedSet<int> reuseIds = new SortedSet<int>();
        private int reservationId;
        private Client client;
        private HotelRoom room;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private double reservationPrice;
        #endregion

        #region properties
        /// <summary>
        /// The reservation id getter and setter.
        /// </summary>
        public int ReservationId { get => reservationId; set => reservationId = value; }

        /// <summary>
        /// The client getter and setter.
        /// </summary>
        public Client Client { get => client; set => client = value; }

        /// <summary>
        /// The room getter and setter.
        /// </summary>
        public HotelRoom Room { get => room; set => room = value; }

        /// <summary>
        /// The check-in date getter and setter 
        /// </summary>
        public string CheckInDate
        {
            get => checkInDate.ToString();
            set
            {
                DateTime date = DateTime.Parse(value);
                checkInDate = date;
                //if (date >= DateTime.Now.AddHours(-20)) checkInDate = date;
                //else throw new ArgumentException("Wrong date");
            }
        }

        /// <summary>
        /// The check-out date getter and setter
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
        /// The reservation price getter and setter
        /// </summary>
        public double ReservationPrice { get => reservationPrice; set => reservationPrice = value; }
        #endregion

        #region constructors
        /// <summary>
        /// The parameterless constructor of reservation that sets the reservationId.
        /// </summary>
        public Reservation()
        {
            rwLock.EnterReadLock();
            try
            {
                if (reuseIds.Count == 0)
                {
                    reservationId = Interlocked.Increment(ref nextID);
                    return;
                }
            }
            finally
            {
                rwLock.ExitReadLock();
            }
            rwLock.EnterWriteLock();
            try
            {
                // Check the count again, because we've released and re-obtained the lock
                if (reuseIds.Count != 0)
                {
                    reservationId = reuseIds.Min;
                    reuseIds.Remove(0);
                    return;
                }
                reservationId = Interlocked.Increment(ref nextID);
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }
        //void Dispose()
        //{
        //    rwLock.EnterWriteLock();
        //    reuseIds.Add(reservationId);
        //    rwLock.ExitWriteLock();
        //}


        /// <summary>
        /// The parameter constructor that sets the reservation data. 
        /// </summary>
        /// <param name="client">client</param>
        /// <param name="room">hotel room </param>
        /// <param name="checkInDate">string check in date</param>
        /// <param name="checkOutDate">string check out date</param>
        public Reservation(Client client, HotelRoom room, string checkInDate, string checkOutDate):this()
        {
            Client = client;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            reservationId++;
            ReservationPrice = HowManyNights() * room.Price;
        }
        #endregion

        #region methods
        /// <summary>
        /// The method that counts for how many nights client will be in the hotel 
        /// </summary>
        /// <returns>int number of nights</returns>
        public int HowManyNights()
        {
            TimeSpan difference = checkOutDate - checkInDate;

            return difference.Days;
        }

        /// <summary>
        /// The clone method of the hotel room to object
        /// </summary>
        /// <returns>object hotel room</returns>
        public object Clone()
        {
            return this.MemberwiseClone() as Reservation;
        }

        /// <summary>
        /// The overridden ToString method 
        /// </summary>
        /// <returns>string description of the reservation</returns>
        public override string ToString()
        {
            string value = "Reservation ID: " + ReservationId + " " + Client + System.Environment.NewLine + "Room:  " + Room + " " + System.Environment.NewLine + "Stay details: " + CheckInDate + "- " + CheckOutDate + System.Environment.NewLine;
            value += "Total prize: " + ReservationPrice + System.Environment.NewLine;
            return value;
        }
        #endregion

    }
}
