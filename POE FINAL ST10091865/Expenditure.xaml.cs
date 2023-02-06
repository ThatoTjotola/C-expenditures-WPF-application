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
    /// Interaction logic for Expenditure.xaml
    /// </summary>
    public partial class Expenditure : Window
    {
        //Variables declared 
        //https://www.w3schools.com/cs/cs_arrays.php
        //(W3schools,2022)
        //Update removal of array and use of generic collection instead
        public static decimal available, available2, grocery, utilities, travel, communication, other;
        public static decimal GetOther()
        {
            return other;
        }
        public static void SetOther(decimal otherexp)
        {
            other = otherexp;
        }
        public static decimal GetAvailable2()
        {
            return available2;
        }
        public static void SetAvailabe2(decimal avail2)
        {
            available2 = avail2;
        }
        public static decimal GetAvailabe()
        {
            return available;
        }

        public static void SetAvailable(decimal avail)
        {
            available = avail;
        }
        public static decimal GetGrocery()
        {
            return grocery;
        }

        public static void SetGrocery(decimal groc)
        {
            grocery = groc;
        }
        public static decimal GetTravel()
        {
            return travel;
        }

        public static void SetTravel(decimal trav)
        {
            travel = trav;
        }
        public static decimal GetUtilties()
        {
            return utilities;
        }

        public static void SetUtilites(decimal util)
        {
            utilities = util;
        }
        public static decimal GetCommunication()
        {
            return communication;
        }

        public static void SetCommunication(decimal comm)
        {
            communication = comm;
        }
       
        //https://stackoverflow.com/questions/65837593/array-which-stores-information-from-user-input
        //(stackoverflow,2022)
        public Expenditure()
        {
            InitializeComponent();
            this.Closed += MainWindow_Closed;
            this.Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            string msg = "Do you want to close without saving?";
            MessageBoxResult result = MessageBox.Show(msg, "Jimmy Financial App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
        }

        private void groceries_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(groceries.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                groceries.Text = groceries.Text.Remove(groceries.Text.Length - 1);

            }
        }

        private void Utilities_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Utilities.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                Utilities.Text = Utilities.Text.Remove(Utilities.Text.Length - 1);

            }

        }

        private void TravelCosts_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TravelCosts.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                TravelCosts.Text = TravelCosts.Text.Remove(TravelCosts.Text.Length - 1);

            }
        }

        private void Communication_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Communication.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                Communication.Text = TravelCosts.Text.Remove(Communication.Text.Length - 1);

            }
        }

        
        private void Other_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Other.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                Other.Text = Other.Text.Remove(Other.Text.Length - 1);

            }
        }

        private void Exit1_Click(object sender, RoutedEventArgs e)
        {
           //this.Close();
            Environment.Exit(0);
        }

        private void Save1_Click(object sender, RoutedEventArgs e)
        {
            
            
            grocery = decimal.Parse(this.groceries.Text);
            utilities = decimal.Parse(this.Utilities.Text);
            other = decimal.Parse(this.Other.Text);
            communication = decimal.Parse(this.Communication.Text);
             travel = decimal.Parse(this.TravelCosts.Text);

            MessageBox.Show( "Saved","Jimmy Financial App");

            // Selection window
            Selection select = new Selection();
            select.Owner = this;
            select.Show();

            this.Hide();


        }
        /*private void SetExit1()
        {
            // Assign an image to the button.
            Exit1.cl = Image.FromFile("C:\\Users\\Amogelang\\source\\repos\\POE FINAL ST10091865\\POE FINAL ST10091865\\Images\\close.png");
            // Align the image and text on the button.
            button1.ImageAlign = ContentAlignment.MiddleRight;
            button1.TextAlign = ContentAlignment.MiddleLeft;
        }*/
    }
}
