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

namespace POE_FINAL_ST10091865
{
    /// <summary>
    /// Interaction logic for Renting.xaml
    /// </summary>
    public partial class Renting : Window
    {
        //https://www.w3schools.com/cs/cs_user_input.php
        //(W3schools,2022)
        public static int Rental;
        static int NoMonths,RentFull;

        public static int GetRentFull()
        {
            return RentFull;
        }
        public static void SetRentFull(int rentfull)
        {
            RentFull = rentfull;
        }
        public static int GetNumberOfMonths()
        {
            return NoMonths;
        }
        public static void SetNumberOfMonths(int months)
        {
            NoMonths = months;
        }
        public static int GetRent()
        {
            return Rental;
        }
        public static void SetRent(int rent)
        {
            Rental = rent;

        }
        public Renting()
        {
            InitializeComponent();
        }

        private void RentalAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            //https://www.w3schools.com/cs/cs_user_input.php
            //(W3schools,2022)

            if (System.Text.RegularExpressions.Regex.IsMatch(RentalAmount.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                RentalAmount.Text = RentalAmount.Text.Remove(RentalAmount.Text.Length - 1);

            }
        }

        private void NumberOfMonths_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(NumberOfMonths.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                NumberOfMonths.Text = NumberOfMonths.Text.Remove(NumberOfMonths.Text.Length - 1);

            }
        }

        private void SelectionButton_Click(object sender, RoutedEventArgs e)
        {
            //Selection window
            //https://www.w3schools.com/cs/cs_user_input.php
            //(W3schools,2022)
            Selection select2 = new Selection();
            select2.Owner = this;
            select2.Show();
            this.Hide();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)


        {
            //Capturing of user input
            Rental = int.Parse(this.RentalAmount.Text);
            NoMonths= int.Parse(this.NumberOfMonths.Text);
            //Rental calulation
           RentFull = Rental * NoMonths;

            MessageBox.Show("Total Rental Amount:"+" "+"R" +RentFull,"Jimmy Financial App");


        }
    }
}
