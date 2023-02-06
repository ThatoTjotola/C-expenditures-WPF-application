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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POE_FINAL_ST10091865
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int monthlyIn;
        public static int monthlyTax;

        //Getters and setters
        public static int GetmonthlyIncome()
        {
            return monthlyIn;
        }

        public static void SetmonthlyIn(int monthlyIncome)
        {
            monthlyIn = monthlyIncome;
        }
        public static int GetmonthlyTax()
        {
            return monthlyTax;
        }

        public static void SetmonthlyTax(int Tax)
        {
            monthlyTax = Tax;
        }
        //UserInputmethod 

        public MainWindow()
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

        private void MonthlyIncomeInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            

            if (System.Text.RegularExpressions.Regex.IsMatch(MonthlyIncomeInput.Text,"[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                

            }
            

        }

        private void MonthlyTaxDeductions_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Exception Handling
            if (System.Text.RegularExpressions.Regex.IsMatch(MonthlyTaxDeductions.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                MonthlyTaxDeductions.Text = MonthlyTaxDeductions.Text.Remove(MonthlyTaxDeductions.Text.Length - 1);

            }
            
            //Conversion of data types


        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(MonthlyIncomeInput.Text))
            {
                MessageBox.Show("Monthly icome is blank or null");
                

            }
            if (String.IsNullOrEmpty(MonthlyTaxDeductions.Text))
            {
                MessageBox.Show("Tax deducuctions is blank or null");
                

            }
            
            
            //Conversion of data types

            monthlyIn = int.Parse(this.MonthlyIncomeInput.Text);
            monthlyTax = int.Parse(this.MonthlyTaxDeductions.Text);

          //Expenditure window
            Expenditure expenses = new Expenditure();
            expenses.Owner = this;
            expenses.Show();

            this.Hide();
        


        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
