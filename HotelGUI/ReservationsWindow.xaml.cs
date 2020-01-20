using HotelSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
