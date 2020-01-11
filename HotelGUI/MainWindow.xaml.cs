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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<HotelRoom> observable;
        Hotel hotel = new Hotel();
        Client client = new Client();
        Address address = new Address();
     
        

        public MainWindow()
        {
            hotel = Hotel.ReadXML("hotel.xml");
            
            Reservation reservation = new Reservation();
            DateTime checkIn;
            DateTime checkOut;
            InitializeComponent();
            listbox_rooms.ItemsSource = hotel.RoomList;
            ComboBox comboBox = new ComboBox();
            comboBox = cb_roomType;
            comboBox.Items.Add("SINGLE");
            comboBox.Items.Add("DOUBLE");
            comboBox.Items.Add("FAMILY");


        }

        private void textBox_firstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string objTextBox = textBox.Text;
            client.FirstName = objTextBox;

        }

        private void textBox_lastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string objTextBox = textBox.Text;
            client.LastName = objTextBox;
        }
        private void textBox_street_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string objTextBox = textBox.Text;
            address.Street1 = objTextBox;
        }

        private void textBox_streetNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string objTextBox = textBox.Text;
            address.StreetNumber1 = objTextBox;
        }

        private void textBox_flatNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string objTextBox = textBox.Text;
            address.FlatNumber = objTextBox;
        }

        private void textBox_postalCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string objTextBox = textBox.Text;
            address.PostalCode = objTextBox;
        }

        private void textBox_city_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string objTextBox = textBox.Text;
            address.City = objTextBox;
        }

        private void textBox_telNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string objTextBox = textBox.Text;
            client.TelNo = objTextBox;
        }

        private void textBox_mail_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string objTextBox = textBox.Text;
            client.MailAddress = objTextBox;
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            textBox_firstName.Text=null;
            textBox_lastName.Text = null;
            textBox_street.Text = null;
            textBox_streetNumber.Text = null;
            textBox_flatNumber.Text = null;
            textBox_postalCode.Text = null;
            textBox_city.Text = null;
            textBox_telNo.Text = null;
            textBox_mail.Text = null;
            radiobutton_male.IsChecked = false;
            radiobutton_female.IsChecked = false;
            datepicker_dateofBirth.Text = null;
            cb_roomType.Text = null;
            datePicker_checkInDate.Text = null;
            datepicker_checkOutDate.Text = null;
            textbox_chosenroom.Text = null;
            textbox_checkinReservation.Text = null;
            textbox_checkoutReservation.Text = null;
            textbox_reservationPrice.Text = null;
        }


    }
}
