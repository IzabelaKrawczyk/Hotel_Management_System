using HotelSystem;
using System.Collections.ObjectModel;
using System.Windows;

namespace HotelGUI
{
    /// <summary>
    /// Interaction logic for ReservationsWindow.xaml
    /// </summary>
    public partial class ReservationsWindow : Window
    {
        private readonly Hotel hotel;
        private readonly ObservableCollection<Reservation> observableReservations;
        /// <summary>
        /// Constructor of the reservations window that shows all the reservations of the hotel. 
        /// </summary>
        /// <param name="hotel"></param>
        public ReservationsWindow(Hotel hotel)
        {
            InitializeComponent();
            this.hotel = hotel;
            observableReservations = new ObservableCollection<Reservation>(hotel.ReservationList);
            ListBox_Reservations.ItemsSource = observableReservations;

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
