using HotelSystem;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace HotelGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<HotelRoom> observable;
        public Hotel hotel = new Hotel();
        public Reservation reservation;

        public MainWindow()
        {
            hotel = Hotel.ReadXML("hotel.xml");
            InitializeComponent();
            observable = new ObservableCollection<HotelRoom>(hotel.RoomList);
            listbox_rooms.ItemsSource = observable;
            _ = new ComboBox();
            ComboBox comboBox = cb_roomType;
            comboBox.Items.Add("SINGLE");
            comboBox.Items.Add("DOUBLE");
            comboBox.Items.Add("FAMILY");
        }


        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            textBox_firstName.Text = null;
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
            observable = new ObservableCollection<HotelRoom>(hotel.RoomList);
            listbox_rooms.ItemsSource = observable;
        }

        private void Button_Check_Click(object sender, RoutedEventArgs e)
        {
            HotelRoom room = new HotelRoom();
            Address address = new Address();
            Client client = new Client();
            string temp = textBox_firstName.Text;
            try 
            { client.FirstName = temp; }
            catch (ArgumentException)
            { MessageBox.Show("Wrong first name!", "Important Message"); }
                   

            temp = textBox_lastName.Text;
            try 
            { client.LastName = temp; }
            catch(ArgumentException)
            { MessageBox.Show("Wrong last name!", "Important Message"); }


            if (radiobutton_male == null && radiobutton_female == null)
            MessageBox.Show("Select gender", "Important Message");
               client.Gender1 = (bool)radiobutton_male.IsChecked ? "M" : "F";                 

           try
           { client.DateOfBirth = datepicker_dateofBirth.SelectedDate.ToString(); }
           catch (Exception)
           { MessageBox.Show("You are to young!", "Important Message"); }

            temp = textBox_telNo.Text;
            try 
            { client.TelNo = temp; }
            catch (Exception)
            { MessageBox.Show("Wrong telephone number!", "Important Message"); }

            temp = textBox_mail.Text;
            try
            { client.MailAddress = temp; }
            catch (Exception)
            { MessageBox.Show("Wrong e-mail address", "Important Message"); }

            temp = textBox_street.Text;
            try 
            { address.Street1 = temp; }
            catch (Exception) 
            { MessageBox.Show("Wrong street name ", "Important Message"); }

            temp = textBox_streetNumber.Text;
            try 
            { address.StreetNumber1 = temp; }
            catch(Exception)
            { MessageBox.Show("Wrong street number!", "Important Message"); }

            temp = textBox_flatNumber.Text;
            address.FlatNumber = temp;

            temp = textBox_postalCode.Text;
            try 
            { address.PostalCode = temp; }
            catch(Exception)
            { MessageBox.Show("Wrong postal code!", "Important Message"); }

            temp = textBox_city.Text;
            try { address.City = temp; }
            catch (Exception)
            { MessageBox.Show("Wrong city name!", "Important Message"); }

            client.Address = address;

            room.RoomType1 = cb_roomType.Text;
            string[] roomData = listbox_rooms.SelectedItem.ToString().Split(' ');
            room.RoomID = Int32.Parse(roomData[2]);
            room.Name = roomData[3]; 
            room.Price = Double.Parse(roomData[5]);

            reservation = new Reservation(client, room, datePicker_checkInDate.SelectedDate.ToString(), datepicker_checkOutDate.SelectedDate.ToString());
            
            ReservationWindow reservationWindow = new ReservationWindow(reservation, hotel);
            reservationWindow.ShowDialog();
        }


        private void Button_Filter_Click(object sender, RoutedEventArgs e)
        {
            if (cb_roomType.SelectedItem != null && datePicker_checkInDate.SelectedDate != null && datepicker_checkOutDate.SelectedDate != null)
            {
                string checkindate = datePicker_checkInDate.SelectedDate.ToString();
                string checkoutdate = datepicker_checkOutDate.SelectedDate.ToString();
                string roomType = cb_roomType.SelectedItem.ToString();
                observable = new ObservableCollection<HotelRoom>();

                for (int i = 0; i < hotel.RoomList.Count; i++)
                {
                    if (hotel.RoomList[i].RoomType1.Equals(roomType))
                        if (hotel.IsRoomFree(checkindate, checkoutdate, hotel.RoomList[i]))
                            observable.Add(hotel.RoomList[i]);
                }
                listbox_rooms.ItemsSource = observable;
            }
            else MessageBox.Show("Select room type, check-in date, check-out date.", "Important Message");
        }

        private void Button_AllReservations_Click(object sender, RoutedEventArgs e)
        {
            ReservationsWindow okno = new ReservationsWindow(hotel);
            okno.ShowDialog();
        }
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {


            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                hotel = Hotel.ReadXML(filename);

                listbox_rooms.ClearValue(ItemsControl.ItemsSourceProperty);
                observable = new ObservableCollection<HotelRoom>(hotel.RoomList);
                listbox_rooms.ItemsSource = observable;
            }


        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                Hotel.WriteXML(filename, hotel);
            }

        }
    }
}
