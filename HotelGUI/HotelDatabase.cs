using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelGUI
{
    /// <summary>
    /// The form of the database with reservations of the hotel 
    /// </summary>
    public partial class HotelDatabase : Form
    {
        /// <summary>
        /// Constructor of the window HotelDatabase
        /// </summary>
        public HotelDatabase()
        {
            InitializeComponent();
        }

        private void HotelReservationTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hotelReservationTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hotelReservationDatabaseDataSet);

        }

        private void HotelDatabase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hotelReservationDatabaseDataSet.HotelReservationTable' table. You can move, or remove it, as needed.
            this.hotelReservationTableTableAdapter.Fill(this.hotelReservationDatabaseDataSet.HotelReservationTable);
            cB_RoomType.Items.Add("");
            cB_RoomType.Items.Add("SINGLE");
            cB_RoomType.Items.Add("DOUBLE");
            cB_RoomType.Items.Add("FAMILY");

            cB_Gender.Items.Add("");
            cB_Gender.Items.Add("F");
            cB_Gender.Items.Add("M");
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "Hotel System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(iExit==DialogResult.Yes)
            {
               this.Close();
            }
        }

        private void Button_Next_Click(object sender, EventArgs e)
        {
            hotelReservationTableBindingSource.MoveNext();
        }

        private void Button_Previous_Click(object sender, EventArgs e)
        {
            hotelReservationTableBindingSource.MovePrevious();
        }
        private void Button_First_Click(object sender, EventArgs e)
        {
            hotelReservationTableBindingSource.MoveFirst();
        }

        private void Button_Last_Click(object sender, EventArgs e)
        {
            hotelReservationTableBindingSource.MoveLast();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hotelReservationTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hotelReservationDatabaseDataSet);
        }

        private void CB_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cB_Gender.Text.Length==0) genderTextBox.Text = "No";
            else
            {
                if (cB_Gender.Text == "F") genderTextBox.Text = "F";
                else genderTextBox.Text = "M";
            }
            
            
        }

        private void CB_RoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cB_RoomType.Text.Length == 0) room_typeTextBox.Text = "No";
            else
            {
                if (cB_RoomType.Text == "SINGLE") room_typeTextBox.Text = "SINGLE";
                else if (cB_RoomType.Text == "DOUBLE") room_typeTextBox.Text = "DOUBLE";
                else room_typeTextBox.Text = "FAMILY";
            }
            
        }

        private void Button_Total_Click(object sender, EventArgs e)
        {
            DateTime checkIn, checkOut;
            int days;
            double singleRoomPrice, doubleRoomPrice, familyRoomPrice;

            singleRoomPrice = 150.0;
            doubleRoomPrice = 300.0;
            familyRoomPrice = 500.0;

            checkIn = Convert.ToDateTime(check__in_dateDateTimePicker.Value);
            checkOut = Convert.ToDateTime(check_out_dateDateTimePicker.Value);
            days = (checkOut - checkIn).Days;
            if(cB_RoomType.Text=="SINGLE")
                lTotalPrice.Text = (days * singleRoomPrice * 1.0).ToString("C");
            if (cB_RoomType.Text == "DOUBLE")
                lTotalPrice.Text = (days * doubleRoomPrice * 1.0).ToString("C");
            if (cB_RoomType.Text == "FAMILY")
                lTotalPrice.Text = (days * familyRoomPrice * 1.0).ToString("C");
        }


    }
}
