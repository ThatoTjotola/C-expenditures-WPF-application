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
    /// Interaction logic for BuyProperty.xaml
    /// </summary>
    /// 
    abstract class Homeloan
    {
        public void HomeloanAppoved()
        {
            MessageBox.Show( "Home Loan approved congratulations", "Jimmy Financial App");
        }
        public abstract void HomeLoanNotApproved();

    }
    class ExpenseLoan : Homeloan
    {
        public override void HomeLoanNotApproved()
        {
            MessageBox.Show( "Hoamloan not approved very unlikely","Jimmy Financial App");
        }
    }

    public partial class BuyProperty : Window
    {

        //https://www.w3schools.com/cs/cs_user_input.php
        //(W3schools,2022)
        public static decimal PurchaseP, TotalDepos, InterestRate, Rental;
        static int NoMonths;
        
        static decimal sum;
        public static decimal MonthlyRepay;
        //Updates done for Property class
        static ExpenseLoan ObjMine = new ExpenseLoan();

        public decimal Monthlypay
        {
            get
            {
                return MonthlyRepay;
            }
            set
            {
                Monthlypay = value;
            }
        }
        public decimal Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
            }
        }

        public static decimal GetPurchasePrice()
        {
            return PurchaseP;
        }

        public static void SetPurchasePrice(decimal price)
        {
            PurchaseP = price;
        }
        public static decimal GetTotalDeposit()
        {
            return TotalDepos;
        }

        public static void SetTotalDeposit(decimal deposit)
        {
            TotalDepos = deposit;
        }
        public static decimal GetInterestRate()
        {
            return InterestRate;
        }
        public static void SetInterestRate(decimal rate)
        {
            InterestRate = rate;
        }
        public static int GetNumberOfMonths()
        {
            return NoMonths;
        }
        public static void SetNumberOfMonths(int months)
        {
            NoMonths = months;
        }
        public static void AvailableMoney()
        {

            //Available Money calculation 

            Expenditure.available = MonthlyRepay + MainWindow.monthlyTax + Expenditure.communication + Expenditure.utilities
                + Expenditure.travel + Expenditure.grocery + Expenditure.other;
            Expenditure.available2 = MainWindow.monthlyIn - Expenditure.available;
            MessageBox.Show("Available Funds : " +" "+ "R" + Expenditure.available2);
        }
        public BuyProperty()
        {
            InitializeComponent();
        }

        private void PurchasePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(PurchasePrice.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                PurchasePrice.Text = PurchasePrice.Text.Remove(PurchasePrice.Text.Length - 1);

            }
        }

        private void Deposit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Deposit.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                Deposit.Text = Deposit.Text.Remove(Deposit.Text.Length - 1);

            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            //Calling of selection window
            Selection selection = new Selection();
            selection.Owner = this;
            selection.Show();

            this.Hide();

        }

        private void Interest_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Interest.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter only numbers");
                Interest.Text = Interest.Text.Remove(Interest.Text.Length - 1);

            }
        }

        private void Months_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Months.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a number  ");
                Months.Text = Months.Text.Remove(Months.Text.Length - 1);

            }
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            PurchaseP = decimal.Parse(this.PurchasePrice.Text);

            TotalDepos = decimal.Parse(this.Deposit.Text);

            InterestRate = decimal.Parse(this.Interest.Text);

            NoMonths = int.Parse(this.Months.Text);

            //HomeLoanRepayment

            // Calculating Monthly Loan Repayment Updated
            decimal p = PurchaseP - TotalDepos;
            MessageBox.Show( " Amount to Pay" +" "+"R" + p, "Jimmy Financial App");

            decimal i = InterestRate / 100;
            MessageBox.Show( "Interest Rate " +" " + i, "Jimmy Financial App");

            decimal m = NoMonths;
            MessageBox.Show( "Number of Months to Repay" +" "+ m, "Jimmy Financial App");

            int n = NoMonths / 12;
            MessageBox.Show( "Number of years" +" "+ n, "Jimmy Financial App");

            //finance calculation to get monthly loan repayment
            decimal Loan = p * (1 + (i * n));
            MonthlyRepay = Loan / m;

            //Rounding off
            MonthlyRepay = Math.Round(MonthlyRepay, 2);
            MessageBox.Show( "Monthly Repayment is " +" " + " R" + MonthlyRepay, "Jimmy Financial App");

            const decimal perc2 = 1 / 3;
            decimal third = MainWindow.monthlyIn * perc2;
            //Condition for MonthlyRepayment can not be more than a 1/3 of Monthly Income
            if (MonthlyRepay > third)
            {
                //Updates made too improve inheritance
                ObjMine.HomeloanAppoved();
                AvailableMoney();

                //Vechile.VechileSelection();


               // Console.Read();

            }
            else
                //Updates made too impove inheritance
                ObjMine.HomeLoanNotApproved();



        }
    }
}
