using HotelSystem;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace HotelGUI
{
    /// <summary>
    /// Interaction logic for ReservationsWindow.xaml
    /// </summary>
    public partial class ReservationsWindow : Window
    {
        //private Hotel hotel;
        private ObservableCollection<string> observableReservations;

        public ReservationsWindow(Hotel hotel)
        {
            InitializeComponent();
            //this.hotel = hotel;
            
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = HotelDatabase; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection cnn= new SqlConnection(connectionString);
            cnn.Open();
            //MessageBox.Show("Connection open!");
            SqlCommand command;
            SqlDataReader dataReader;
            string sql, Output = "";

            sql = "Select ReservationId, ClientId, RoomId, CheckInDate, CheckOutDate, ReservationPrice from Reservation";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            Collection<string> reservations = new Collection<string>(); 
            while(dataReader.Read())
            {
                reservations.Add("Reservation id: " + dataReader.GetValue(0) + ", client id: " + dataReader.GetValue(1) + ", room id: " + dataReader.GetValue(2) + ", check-in date: " + dataReader.GetValue(3) + ", check-out date: " + dataReader.GetValue(4) + ", reservation price:  " + dataReader.GetValue(5)); 
            }
            observableReservations = new ObservableCollection<string>(reservations);
            ListBox_Reservations.ItemsSource = observableReservations;
            cnn.Close();
        }


        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
