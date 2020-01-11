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
    public class Hotel: ICloneable, ISaving
    {
        private int reservationsNumber;
        private List<Client> clientList;
        private List<HotelRoom> roomList;
        private List<Reservation> reservationList;
        private int roomsNumber;

        public List<Client> ClientList { get => clientList; set => clientList = value; }
        internal List<HotelRoom> Rooms { get => RoomList; set => RoomList = value; }
        public int ReservationsNumber { get => reservationsNumber;}
        internal List<Reservation> ReservationList { get => reservationList; set => reservationList = value; }
        public int RoomsNumber { get => roomsNumber;}
        public List<HotelRoom> RoomList { get => roomList; set => roomList = value; }

        public Hotel()
        {
            reservationsNumber = 0;
            roomsNumber = 0;
            clientList= new List<Client>();
            RoomList = new List<HotelRoom>();
            reservationList = new List<Reservation>();

        }
        public Hotel(List<HotelRoom> rooms):this()
        {
            this.RoomList = new List<HotelRoom>(rooms);
            roomsNumber = RoomList.Count;
        }


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

        public override string ToString()
        {
            StringBuilder myStringBuilder = new StringBuilder("Rezerwacje hotelu: " + Environment.NewLine);
            foreach (Reservation res in reservationList)
                myStringBuilder.AppendLine(res?.ToString()); //odpali gdy c nie jest nullem

            return myStringBuilder.ToString();
        }


        public int clientTimes(Client client)
        {
            int counter = 0;
            foreach(Reservation res in reservationList)
                if(res.Client==client) counter++;
            return counter;
        }

        public double getReservationPrice(int reservationId)
        {
            Reservation temp = new Reservation();
            temp = reservationList.Find(i => i.ReservationId == reservationId);

            return temp.ReservationPrice;
        }

        public void removeRoom(HotelRoom r)
        {
            if (!Rooms.Contains(r)) Console.WriteLine("There is no such a room");
            else
            {
                Rooms.Remove(r);
                roomsNumber--;
            }
                
        }

        public void removeClient(string firstName, string lastName, Client.Gender gender, DateTime dataUrodzenia)
        {
            reservationList.RemoveAll(c => c.Client.FirstName == firstName && c.Client.LastName == lastName && c.Client.Gender1 ==gender.ToString() && c.Client.DateOfBirth ==dataUrodzenia.ToString());
            reservationsNumber = reservationList.Count;
        }

        public bool isRoomFree(string checkIndate, string checkOutdate, HotelRoom room)
        {
            DateTime checkIn = DateTime.Parse(checkIndate);
            DateTime checkOut = DateTime.Parse(checkOutdate);

            foreach (Reservation r in reservationList)
            {
                DateTime tempIn = DateTime.Parse(r.CheckInDate);
                DateTime tempOut = DateTime.Parse(r.CheckOutDate);
                r.Room = room;
                if (checkIn <= tempIn && checkOut <= tempOut) return false;
                if (checkIn >= tempIn && checkOut <= tempOut) return false;
                if (checkIn < tempOut && checkOut >= tempOut) return false;
            }
            return true;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

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

        public void WriteBIN(string nazwa)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(nazwa, FileMode.Create))
            {
                formatter.Serialize(stream, this);
                stream.Close();
            }
        }

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

        public static void WriteXML(string nazwa, Hotel h)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Hotel));
            StreamWriter writer = new StreamWriter(nazwa);
            serializer.Serialize(writer, h);
            writer.Close();

        }

        public static Hotel ReadXML(string nazwa)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Hotel));
            FileStream fs = new FileStream(nazwa, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            Hotel odczytany = (Hotel)serializer.Deserialize(reader);
            fs.Close();
            return odczytany;
        }

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
