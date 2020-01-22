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
        private Hotel hotel;
        private ObservableCollection<Reservation> observableReservations;

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
