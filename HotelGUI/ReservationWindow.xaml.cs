using HotelSystem;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace HotelGUI
{
    /// <summary>
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class ReservationWindow : Window
    {
        private readonly Hotel hotel;
        private readonly Reservation reservation;

        public ReservationWindow()
        {
            InitializeComponent();
        }

        public ReservationWindow(HotelSystem.Reservation reservation, Hotel hotel) : this()
        {
            this.hotel = hotel;
            this.reservation = reservation;
            if (reservation != null)
            {
                textbox_client.Text = reservation.Client.ToString();
                textblock_Reservation.Text = reservation.Room + System.Environment.NewLine + "Stay details: " + reservation.CheckInDate + " - " + reservation.CheckOutDate + System.Environment.NewLine + "Total cost: " + reservation.ReservationPrice;
            }
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = HotelDatabase; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter dataAdapter=new SqlDataAdapter();
            
            int id = reservation.Client.Address.AddressID1;
            string val1 = reservation.Client.Address.Street1;
            string val2 = reservation.Client.Address.StreetNumber1;
            string val3 = reservation.Client.Address.FlatNumber;
            string val4 = reservation.Client.Address.City;
            string val5 = reservation.Client.Address.PostalCode;
           
            string sql = "Insert into Address (AddressId, StreetName, StreetNumber, FlatNumber, CityName, PostalCode) values(@id,'"+val1+"','"+ val2+"','"+ val3+"','"+ val4+"', '"+val5+"')";
            command = new SqlCommand(sql, cnn);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            dataAdapter.InsertCommand = command;
            dataAdapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();

            int id1 = reservation.Client.ClientId;
            val1 = reservation.Client.FirstName;
            val2 = reservation.Client.LastName;
            DateTime date = DateTime.Parse(reservation.Client.DateOfBirth);
            val4 = reservation.Client.Gender1;
            val5 = reservation.Client.TelNo;
            sql = "Insert into Client (ClientId, FirstName, LastName, DateOfBirth, Gender, TelephoneNo, AddressId) values(@id1,'" + val1+"','"+val2+"',@date,'"+ val4+"','"+ val5+"', @id ) ";
            command = new SqlCommand(sql, cnn);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.Parameters.Add("@id1", System.Data.SqlDbType.Int).Value = id1;
            command.Parameters.Add("@date", System.Data.SqlDbType.DateTime).Value = date;
            dataAdapter.InsertCommand = command;
            dataAdapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();

            id = reservation.ReservationId;
            date = DateTime.Parse(reservation.CheckInDate);
            DateTime date1 = DateTime.Parse(reservation.CheckOutDate);
            id1 = reservation.Client.ClientId;
            int id2 = reservation.Room.RoomID;
            float price = (float)reservation.ReservationPrice;
            sql = "Insert into Reservation (ReservationId, ClientId, RoomId, CheckInDate, CheckOutDate, ReservationPrice) values(@id, @id1, @id2, @date, @date1, @price)";
            command = new SqlCommand(sql, cnn);
            command.Parameters.Add("@id",System.Data.SqlDbType.Int).Value=id;
            command.Parameters.Add("@id1", System.Data.SqlDbType.Int).Value= id1;
            command.Parameters.Add("@id2", System.Data.SqlDbType.Int).Value = id2;
            command.Parameters.Add("@date", System.Data.SqlDbType.DateTime).Value= date;
            command.Parameters.Add("@date1", System.Data.SqlDbType.DateTime).Value = date1;
            command.Parameters.Add("@price", System.Data.SqlDbType.Float).Value = price;
            dataAdapter.InsertCommand = command;
            dataAdapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();

            hotel.AddReservation(reservation.Client, reservation.Room, reservation.CheckInDate, reservation.CheckOutDate);
            this.Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
