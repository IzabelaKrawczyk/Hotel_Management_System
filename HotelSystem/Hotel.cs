using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HotelSystem
{
    [Serializable]
    ///<summary>
    ///Class that represents a hotel with list of clients, rooms, and reservations
    ///</summary>
    public class Hotel: ICloneable, ISaving
    {
        private int reservationsNumber;
        private List<Client> clientList;
        private List<HotelRoom> roomList;
        private List<Reservation> reservationList;
        private int roomsNumber;
        /// <summary>
        /// List of clients of hotel
        /// </summary>
        public List<Client> ClientList { get => clientList; set => clientList = value; }
        /// <summary>
        /// Integer number of reservations
        /// </summary>
        public int ReservationsNumber { get => reservationsNumber;}
        /// <summary>
        /// List of reservations
        /// </summary>
        public List<Reservation> ReservationList { get => reservationList; set => reservationList = value; }
        /// <summary>
        /// Integer number of rooms in the hotel
        /// </summary>
        public int RoomsNumber { get => roomsNumber;}
        /// <summary>
        /// List of rooms in the hotel
        /// </summary>
        public List<HotelRoom> RoomList { get => roomList; set => roomList = value; }
        /// <summary>
        /// Paramterless hotel constructor
        /// </summary>
        public Hotel()
        {
            reservationsNumber = 0;
            roomsNumber = 0;
            clientList= new List<Client>();
            RoomList = new List<HotelRoom>();
            reservationList = new List<Reservation>();

        }
        /// <summary>
        /// Parameter constructor of the hotel
        /// </summary>
        /// <param name="rooms"> List of HotelRoom</param>
        public Hotel(List<HotelRoom> rooms):this()
        {
            this.RoomList = new List<HotelRoom>(rooms);
            roomsNumber = RoomList.Count;
        }

        /// <summary>
        /// Mathod that adds client if does not exista and the reservation to the hotel
        /// </summary>
        /// <param name="c">client</param>
        /// <param name="r">hotel room</param>
        /// <param name="checkInDate">check-in date string</param>
        /// <param name="checkOutDate">check-out date string</param>
        public void AddReservation(Client c, HotelRoom r, string checkInDate, string checkOutDate)
        {

            if (isRoomFree(checkInDate, checkOutDate, r))
            {
                if (clientTimes(c)>=1)
                {
                    Reservation res = new Reservation(c, r, checkInDate, checkOutDate);
                    res.ReservationPrice = 0.9 * r.Price * res.HowManyNights();
                    reservationList.Add(res);
                    reservationsNumber++;
                }
                else
                {
                    ClientList.Add(c);
                    Reservation res = new Reservation(c, r, checkInDate, checkOutDate);
                    res.ReservationPrice = 1.0 * r.Price * res.HowManyNights();
                    reservationList.Add(res);
                    reservationsNumber++;
                }
            }
            else throw new Exception("Room is not free or it doesn't exist.");

        }
        /// <summary>
        /// Method that adds reservation to hotel system
        /// </summary>
        /// <param name="reservation"></param>
        public void AddReservation(Reservation reservation)
        {
            if (isRoomFree(reservation.CheckInDate, reservation.CheckOutDate, reservation.Room))
            {
                if (clientTimes(reservation.Client) >= 1)
                {
                    reservation.ReservationPrice = 0.9 * reservation.Room.Price * reservation.HowManyNights();
                    reservationList.Add(reservation);
                    reservationsNumber++;
                }
                else
                {
                    ClientList.Add(reservation.Client);
                    reservation.ReservationPrice = 0.9 * reservation.Room.Price * reservation.HowManyNights();
                    reservationList.Add(reservation);
                    reservationsNumber++;
                }
            }
            else throw new Exception("Room is not free or it doesn't exist.");
        }
        /// <summary>
        /// Overridden ToString method
        /// </summary>
        /// <returns>string description of the hotel reservations</returns>
        public override string ToString()
        {
            StringBuilder myStringBuilder = new StringBuilder("Rezerwacje hotelu: " + Environment.NewLine);
            foreach (Reservation res in reservationList)
                myStringBuilder.AppendLine(res?.ToString()); //odpali gdy c nie jest nullem

            return myStringBuilder.ToString();
        }

        /// <summary>
        /// Method that counts how many times client had reserved any rooms in the hotel 
        /// </summary>
        /// <param name="client"></param>
        /// <returns>int</returns>
        public int clientTimes(Client client)
        {
            int counter = 0;
            foreach(Reservation res in reservationList)
                if(res.Client==client) counter++;
            return counter;
        }
        /// <summary>
        /// Mathod that counts what is the price of the reservation
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns>double</returns>
        public double getReservationPrice(int reservationId)
        {
            Reservation temp = new Reservation();
            temp = reservationList.Find(i => i.ReservationId == reservationId);

            return temp.ReservationPrice;
        }
        /// <summary>
        /// Mathod that removes the room from the list of hotel rooms
        /// </summary>
        /// <param name="r">hotelroom</param>
        public void removeRoom(HotelRoom r)
        {
            if (!RoomList.Contains(r)) Console.WriteLine("There is no such a room");
            else
            {
                RoomList.Remove(r);
                roomsNumber--;
            }
                
        }
        /// <summary>
        /// Method that removes client from the hotel system
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="gender"></param>
        /// <param name="dataUrodzenia"></param>
        public void removeClient(string firstName, string lastName, Client.Gender gender, DateTime dataUrodzenia)
        {
            reservationList.RemoveAll(c => c.Client.FirstName == firstName && c.Client.LastName == lastName && c.Client.Gender1 ==gender.ToString() && c.Client.DateOfBirth ==dataUrodzenia.ToString());
            reservationsNumber = reservationList.Count;
        }
        /// <summary>
        /// Mathod that checks if the room is free
        /// </summary>
        /// <param name="checkIndate"></param>
        /// <param name="checkOutdate"></param>
        /// <param name="room"></param>
        /// <returns>bool</returns>
        public bool isRoomFree(string checkIndate, string checkOutdate, HotelRoom room)
        {
            DateTime checkIn = DateTime.Parse(checkIndate);
            DateTime checkOut = DateTime.Parse(checkOutdate);

            foreach (Reservation r in reservationList)
            {
                DateTime tempIn = DateTime.Parse(r.CheckInDate);
                DateTime tempOut = DateTime.Parse(r.CheckOutDate);
                if (r.Room.Equals(room)) 
                {
                    if (checkIn < tempIn && checkOut > tempOut) return false;
                    if (checkIn > tempIn && checkOut < tempOut) return false;
                    if (checkIn > tempIn && checkOut > tempOut) return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Method that clones the hotel object
        /// </summary>
        /// <returns>object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        /// <summary>
        /// Deep copy of the method
        /// </summary>
        /// <returns>hotel</returns>
        public Hotel DeepCopy()
        {
            Hotel copy = new Hotel();
            var new1 = new List<Client>(clientList.Select(x => ((Client)x.Clone())));
            copy.clientList = new1;
            var new2 = new List<HotelRoom>(RoomList.Select(x => ((HotelRoom)x.Clone())));
            copy.RoomList = new2;
            var new3 = new List<Reservation>(reservationList.Select(x => ((Reservation)x.Clone())));
            copy.ReservationList = new3;
            copy.reservationsNumber = reservationList.Count();
            copy.roomsNumber = RoomList.Count;
            return copy;
        }
        /// <summary>
        /// MEthod that writes the hotel to binary file
        /// </summary>
        /// <param name="nazwa"></param>
        public void WriteBIN(string nazwa)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(nazwa, FileMode.Create))
            {
                formatter.Serialize(stream, this);
                stream.Close();
            }
        }
        /// <summary>
        /// Mathod that reads the binary file to get the hotel object
        /// </summary>
        /// <param name="nazwa"></param>
        /// <returns>object</returns>
        public object ReadBIN(string nazwa)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            object wynik;
            using (Stream stream = new FileStream(nazwa, FileMode.Open))
            {
                wynik = formatter.Deserialize(stream);
            }
            return wynik;

        }
        /// <summary>
        /// Mathod that writes xml file of the hotel object 
        /// </summary>
        /// <param name="nazwa"></param>
        /// <param name="h"></param>
        public static void WriteXML(string nazwa, Hotel h)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Hotel));
            StreamWriter writer = new StreamWriter(nazwa);
            serializer.Serialize(writer, h);
            writer.Close();
        }
        /// <summary>
        /// method that read xml file to get the hotel object 
        /// </summary>
        /// <param name="nazwa"></param>
        /// <returns></returns>
        public static Hotel ReadXML(string nazwa)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Hotel));
            FileStream fs = new FileStream(nazwa, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            Hotel odczytany = (Hotel)serializer.Deserialize(reader);
            fs.Close();
            return odczytany;
        }
        /// <summary>
        /// Method that clones deeply the hotel using binaryformatter
        /// </summary>
        /// <param name="h"></param>
        /// <returns>hotel</returns>
        public static Hotel DeepClone(Hotel h)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, h);
                ms.Position = 0;

                return (Hotel)formatter.Deserialize(ms);
            }
        }



    }
}
