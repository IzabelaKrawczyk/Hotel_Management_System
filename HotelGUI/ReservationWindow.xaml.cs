using HotelSystem;
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

        /// <summary>
        /// The constructor of the reservation window.
        /// </summary>
        public ReservationWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The constructor of the reservation window that shows reservation made in MainWindow.
        /// </summary>
        /// <param name="reservation"></param>
        /// <param name="hotel"></param>
        public ReservationWindow(HotelSystem.Reservation reservation, Hotel hotel) : this()
        {
            this.hotel = hotel;
            this.reservation = reservation;
            if (reservation != null)
            {
                textbox_client.Text = reservation.Client.ToString();
                textblock_Reservation.Text = reservation.Room.ToString() + System.Environment.NewLine + "Stay details: " + reservation.CheckInDate + " - " + reservation.CheckOutDate + System.Environment.NewLine + "Total cost: " + reservation.ReservationPrice;
            }
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            hotel.AddReservation(reservation.Client, reservation.Room, reservation.CheckInDate, reservation.CheckOutDate);
            this.Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
