using System;
using System.Collections.Generic;
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
using HotelSystem;

namespace HotelGUI
{
    /// <summary>
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class ReservationWindow : Window
    {
        private Hotel hotel;
        private Reservation reservation;
        
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
                textblock_Reservation.Text = reservation.Room.ToString()+System.Environment.NewLine+"Stay details: "+reservation.CheckInDate+" - "+reservation.CheckOutDate+ System.Environment.NewLine + "Total cost: "+reservation.ReservationPrice;
            }
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            hotel.AddReservation(reservation.Client,reservation.Room,reservation.CheckInDate,reservation.CheckOutDate);
            this.Close();
        }

        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
