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
        HotelRoom room=new HotelRoom();
        Address address = new Address();
       
        Reservation reservation;
     
        

        public MainWindow()
        {
            hotel = Hotel.ReadXML("hotel.xml");
            InitializeComponent();
            observable = new ObservableCollection<HotelRoom>(hotel.RoomList);
            listbox_rooms.ItemsSource = observable;
            ComboBox comboBox = new ComboBox();
            comboBox = cb_roomType;
            comboBox.Items.Add("SINGLE");
            comboBox.Items.Add("DOUBLE");
            comboBox.Items.Add("FAMILY");
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
        }

        private void button_check_Click(object sender, RoutedEventArgs e)
        {
            string temp = textBox_firstName.Text;
            if (temp == null)
                MessageBox.Show("First name is null", "Important Message");
            else
                client.FirstName = temp;

            temp = textBox_lastName.Text;
            if (temp == null)
                MessageBox.Show("Last name is null", "Important Message");
            else
                client.LastName = temp;

            if(radiobutton_male==null && radiobutton_female==null)
                MessageBox.Show("Select gender", "Important Message");
            else
                client.Gender1 = (bool) radiobutton_male.IsChecked ? "M" : "F";

            
            if (datepicker_dateofBirth.SelectedDate == null)
                MessageBox.Show("Date of birth is not selected", "Important Message");
            else
                client.DateOfBirth = datepicker_dateofBirth.SelectedDate.ToString();

            temp= textBox_telNo.Text;
            if(temp==null)
                MessageBox.Show("Telephone number is null", "Important Message");
            else
                client.TelNo = temp;

            temp = textBox_mail.Text;
            if (temp == null)
                MessageBox.Show("Email address is null", "Important Message");
            else
                client.MailAddress = temp;

            temp = textBox_street.Text;
            if (temp == null)
                MessageBox.Show("Street name is null", "Important Message");
            else
                address.Street1 = temp;

            temp = textBox_streetNumber.Text;
            if (temp == null)
                MessageBox.Show("Street number is null", "Important Message");
            else
                address.StreetNumber1 = temp;

            temp = textBox_flatNumber.Text;
            address.FlatNumber = temp;

            temp= textBox_postalCode.Text;
            if (temp == null)
                MessageBox.Show("Postal code is null", "Important Message");
            else
                address.PostalCode = temp;

            temp = textBox_city.Text;
            if (temp == null)
                MessageBox.Show("City name is null", "Important Message");
            else
                address.City = temp;

            client.Address = address;

            room.RoomType1 = cb_roomType.Text;
            var roomData = listbox_rooms.SelectedItem.ToString().Split(' ');
            room.Name = roomData[1];
            room.Price = Double.Parse(roomData[3]);

            reservation = new Reservation(client,room, datePicker_checkInDate.SelectedDate.ToString(), datepicker_checkOutDate.SelectedDate.ToString());

            ReservationWindow reservationWindow = new ReservationWindow(reservation, hotel);
            reservationWindow.ShowDialog();
        }

        private void cb_roomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_roomType.SelectedItem==null)
            {
                listbox_rooms.ItemsSource = hotel.RoomList;
            }
            else
            {
                string roomType = cb_roomType.SelectedItem.ToString();
                observable = new ObservableCollection<HotelRoom>();
                for (int i = 0; i < hotel.RoomList.Count; i++)
                {
                    if (hotel.RoomList[i].RoomType1.Equals(roomType))
                        observable.Add(hotel.RoomList[i]);
                }
                listbox_rooms.ItemsSource = observable;
            }
            
        }
    }
}
