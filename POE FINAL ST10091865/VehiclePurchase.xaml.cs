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
    /// Interaction logic for VehiclePurchase.xaml
    /// </summary>
    /// 
    public static class Vehicle
    {
        //variable declarations for Vehicle class
        public static string modelMake;
        public static int vehiclePrice,vehicleDeposit,vehicleInterest,vehicleInsurance;
        public static decimal monthlyVehicleRepay,totalcostVehicle;
        //Delegate to notify user if expenses exceed 75%
        public delegate void delNotfity();



        //Method for required vechilecalculations
        public static void CalculationMethod()
        {

            const decimal perc = 3 / 4;
            decimal third = MainWindow.monthlyIn * perc;
            decimal expense = Expenditure.available + totalcostVehicle;
            if (third > expense)
            {
                MessageBox.Show("Jimmy Financial App", "Expenses exceed 75% of user income");
                //Environment.Exit(0);
            }
            else
                Generic();


        }
        //Generic collection method 
        public static void Generic()
        {
            //Declaration of generic collection

            
            List<decimal> Exp = new List<decimal>();
            // foreach(GridView )

            //Adding the variables to a generic collection as requested
            Exp.Add(totalcostVehicle);
            Exp.Add(Expenditure.communication);
            Exp.Add(Expenditure.grocery);
            Exp.Add(Expenditure.travel);
            Exp.Add(Expenditure.utilities);
            Exp.Add(BuyProperty.MonthlyRepay);
            Exp.Add(Expenditure.other);



            //Expenses displayed in descending order
            //(stackoverflow,2022).
            
            Exp.Sort((a, b) => b.CompareTo(a));
            for (int i = 0; i < Exp.Count; i++)
            {

                MessageBox.Show( "///\n Expenses displayed in descending order \n>>>" +"R"+ Exp[i], "Jimmy Financial App");
            }
            
            

        }
        //Getters and setters
        public static decimal GetTotalCostVehicle()
        {
            return totalcostVehicle;
        }
        public static void SetTotalCostVehicle(decimal TotalCost)
        {
            totalcostVehicle = TotalCost;
        }
        public static decimal GetMonthlyVehicleRepay()
        {
            return monthlyVehicleRepay;
        }
        public static void SetMonthlyVehicleRepay(decimal MonthlyVehicle)
        {
            monthlyVehicleRepay = MonthlyVehicle;
        }
        public static string GetModelMake()
        {
            return modelMake;
        }
        public static void SetModelMake(string ModelMake)
        {
            modelMake = ModelMake;
        }
        public static int GetVehiclePrice()
        {
            return vehiclePrice;
        }

        public static void SetVehiclePrice(int VehiclePrice)
        {
            vehiclePrice = VehiclePrice;
        }
        public static int GetVehicleDeposit()
        {
            return vehicleDeposit;
        }

        public static void SetVehicleDeposit(int VehicleDeposit)
        {
            vehicleDeposit = VehicleDeposit;
        }

        public static int GetVehicleInterest()
        {
            return vehicleInterest;
        }
        public static void SetVehicleInterest(int VehicleInterest)
        {
            vehicleDeposit = VehicleInterest;
        }

        public static int GetVehicleInsurance()
        {
            return vehicleDeposit;
        }
        public static void SetVehicleInsurance(int VehicleInsurance)
        {
            vehicleInsurance = VehicleInsurance;
        }
    }

        public partial class VehiclePurchase : Window
    {
        public VehiclePurchase()
        {
            InitializeComponent();
        }

        private void ModelMake_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ModelAndMake_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ModelAndMake.Text, "[^A-Z]"))
            {
                MessageBox.Show("Please Enter Model and Make Capitalized", "Jimmy Financial App");
                ModelAndMake.Text = ModelAndMake.Text.Remove(ModelAndMake.Text.Length - 1);

            }
        }

        private void VehiclePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(PurchasePrice.Text, "[^0-9]"))
            {
                MessageBox.Show("Jimmy Financial App", "Please Enter only numbers");
                PurchasePrice.Text = PurchasePrice.Text.Remove(PurchasePrice.Text.Length - 1);

            }
        }

        private void VehicleDeposit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(VehicleDeposit.Text, "[^0-9]"))
            {
                MessageBox.Show("Jimmy Financial App", "Please Enter only numbers");
                VehicleDeposit.Text = VehicleDeposit.Text.Remove(VehicleDeposit.Text.Length - 1);

            }
        }

        private void VehicleInterest_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(VehicleInterest.Text, "[^0-9]"))
            {
                MessageBox.Show("Jimmy Financial App", "Please Enter only numbers");
                VehicleInterest.Text = VehicleInterest.Text.Remove(VehicleInterest.Text.Length - 1);


            }
        }

        private void Insurance_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Insurance.Text, "[^0-9]"))
            {
                MessageBox.Show("Jimmy Financial App", "Please Enter only numbers");
                Insurance.Text = Insurance.Text.Remove(Insurance.Text.Length - 1);

            }
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            Vehicle.modelMake= this.ModelAndMake.Text;
            Vehicle.vehiclePrice= int.Parse(this.PurchasePrice.Text);
            Vehicle.vehicleDeposit = int.Parse(this.VehicleDeposit.Text);
            Vehicle.vehicleInterest = int.Parse(this.VehicleInterest.Text);
            Vehicle.vehicleInsurance = int.Parse(this.Insurance.Text);

            //Formula for monthly repay
            decimal vechp = Vehicle.vehiclePrice - Vehicle.vehicleDeposit;
            MessageBox.Show("\n" + "Amount to pay: "+"R" + vechp,"Jimmy Finacial App");

            const decimal v = 100;
            decimal vechint = Vehicle.vehicleInterest / v;
            MessageBox.Show("Interest rate:" + vechint, "Jimmy Financial app");


            decimal nummonths = 60;
            MessageBox.Show("number of Months to repay :" + nummonths,"Jimmy Financial app");

            decimal years = nummonths / 12;
            MessageBox.Show("Years to Repay: " + years,"Jimmy Financial app");

            //finance calculation to get monthly loan of vechile repayment
            decimal VechileLoan = vechp * (1 + (vechint * years));
            Vehicle.monthlyVehicleRepay = VechileLoan / nummonths;
            Vehicle.totalcostVehicle = Vehicle.monthlyVehicleRepay + Vehicle.vehicleInsurance;
            //Rounding off of total vechile cost
            //(Stackoverflow,2022).

            Vehicle.CalculationMethod();

        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {

            //
            Selection selection2 = new Selection();
            selection2.Owner = this;
            selection2.Show();

            this.Hide();
        }
    }
}
