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
    /// Interaction logic for Save.xaml
    /// </summary>
    public partial class Save : Window
    {
        //Declaration of variables
        public static decimal SavingAmount,Interest,Months,SavingMonths;
        //https://www.w3schools.com/cs/cs_user_input.php
        //(W3schools,2022)
        public static decimal GetSavingMonths()
        {
            return SavingMonths;
        }
        public static void SetSavingMonths(decimal savingmonths)
        {
            SavingMonths = savingmonths;
        }
        public static decimal GetSavingAmount()
        {
            return SavingAmount;
        }
        public static void SetSavingAmount(decimal SaveAmount)
        {
            SavingAmount = SaveAmount;
        }
        public static decimal GetMonths()
        {
            return Months;
        }
        public static void SetMonths(decimal NoMonths)
        {
            Months = NoMonths;
        }
        public static decimal GetInterest()
        {
            return Interest;
        }
        public static void SetInterest(decimal interest)
        {
            Interest = interest;
        }

        private void SavingPeriod_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Regulating of user input
            //https://www.w3schools.com/cs/cs_user_input.php
            //(W3schools,2022)
            if (System.Text.RegularExpressions.Regex.IsMatch(SavingPeriod.Text, "[^0-9]"))
            {
                MessageBox.Show( "Please Enter only numbers","Jimmy Financial App");
                SavingPeriod.Text = SavingPeriod.Text.Remove(SavingPeriod.Text.Length - 1);

            }
        }

        private void InterestRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            //https://www.w3schools.com/cs/cs_user_input.php
            //(W3schools,2022)
            if (System.Text.RegularExpressions.Regex.IsMatch(InterestRate.Text, "[^0-9]"))
            {
                MessageBox.Show( "Please Enter only numbers","Jimmy Financial app");
                InterestRate.Text = InterestRate.Text.Remove(InterestRate.Text.Length - 1);

            }
            
        }

        private void Selection_Click(object sender, RoutedEventArgs e)
        {
            //Calling Selection window on button click
            Selection sel = new Selection();
            sel.Owner = this;
            sel.Show();
            this.Hide();
        }

        private void calulate_Click(object sender, RoutedEventArgs e)
        {
            //Necessary calculations
            //https://www.w3schools.com/cs/cs_user_input.php
            //(W3schools,2022)
            if(String.IsNullOrEmpty(InterestRate.Text))
            {
                MessageBox.Show("Interest Rate is Blank");
                
            }
            if(String.IsNullOrEmpty(AmountToSave.Text))
            {
                MessageBox.Show("Amount to save is blank or null");
            }
            if (String.IsNullOrEmpty(SavingPeriod.Text))
            {
                MessageBox.Show("Amount to save is blank or null");
            }
            else

            Interest = int.Parse(this.InterestRate.Text);
            SavingAmount = int.Parse(this.AmountToSave.Text);
            Months = int.Parse(this.SavingPeriod.Text);

            decimal i = Interest / 100;
            MessageBox.Show("Interest Rate " + " " + i, "Jimmy Financial App");

            decimal m = Months;
            MessageBox.Show("Number of saving" + " " + m, "Jimmy Financial App");

            decimal n = Months / 12;
            MessageBox.Show("Number of years" + " " + n, "Jimmy Financial App");

            //finance calculation to get monthly loan repayment
            decimal saving = SavingAmount * (1 + (i * n));
            SavingMonths = saving / m;

            //Rounding off
            SavingMonths = Math.Round(SavingMonths, 2);
            MessageBox.Show("Monthly Savings Repayment for F1 kyalami:" + " " + " R" + SavingMonths, "Jimmy Financial App");
        }

        public Save()
        {
            InitializeComponent();
        }

        private void AmountToSave_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(AmountToSave.Text, "[^0-9]"))
            {
                MessageBox.Show( "Please Enter only numbers","Jimmy Financial App");
                AmountToSave.Text = AmountToSave.Text.Remove(AmountToSave.Text.Length - 1);

            }
        }
    }
}
