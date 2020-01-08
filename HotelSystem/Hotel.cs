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
    class Hotel: ICloneable, ISaving
    {
        private int reservationsNumber;
        private List<Client> reservations;
        private List<HotelRoom> rooms;
        private int roomsNumber;

        public int LiczbaRezerwacji { get => reservationsNumber; set => reservationsNumber = value; }
        public List<Client> Reservations { get => reservations; set => reservations = value; }
        internal List<HotelRoom> Rooms { get => rooms; set => rooms = value; }

        public Hotel()
        {
            LiczbaRezerwacji = 0;
            roomsNumber = 0;
            Reservations= new List<Client>();
            rooms = new List<HotelRoom>();
        }
        public Hotel(List<HotelRoom> rooms):this()
        {
            this.rooms = new List<HotelRoom>(rooms);
            roomsNumber = rooms.Count;

        }

        public Hotel(List<Client> reservations)
        {
            this.Reservations = reservations;
            LiczbaRezerwacji++;
        }

        public void DodajRezerwacje(Client c)
        {
            if(isRoomFree(c.HotelRoom))
            Reservations.Add(c);
            LiczbaRezerwacji++;
        }

        public override string ToString()
        {
            StringBuilder myStringBuilder = new StringBuilder("Rezerwacje: " + Environment.NewLine);
            foreach (Client c in Reservations)
                myStringBuilder.AppendLine(c?.ToString()); //odpali gdy c nie jest nullem

            return myStringBuilder.ToString();
        }

        public bool isRoomFree(HotelRoom room)
        {
            if (!Rooms.Contains(room)) return false;
            else
            {
                foreach (Client c in Reservations)
                    if (c.HotelRoom == room) return false;
            }
            return true;
        }

        public int clientTimes(Client client)
        {
            int counter = 0;
            foreach (Client c in Reservations)
                if (c == client) counter++;
            return counter;
        }

        public double reservationPrice(Client c)
        {
            //for regular customers
            if (clientTimes(c)>1)
               c.HotelRoom.Price = 0.9 * c.HotelRoom.Price;
           return c.HotelRoom.Price;
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
            Reservations.RemoveAll(c => c.FirstName == firstName && c.LastName == lastName && c.Gender1==gender&& c.DataUrodzenia==dataUrodzenia);
            reservationsNumber = reservations.Count;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Hotel DeepCopy()
        {
            Hotel copy = new Hotel();
            var new1 = new List<Client>(reservations.Select(x => ((Client)x.Clone())));
            copy.reservations = new1;
            var new2 = new List<HotelRoom>(rooms.Select(x => ((HotelRoom)x.Clone())));
            copy.rooms = new2;
            copy.LiczbaRezerwacji = reservations.Count();

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
