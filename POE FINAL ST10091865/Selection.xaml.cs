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
    /// Interaction logic for Selection.xaml
    /// </summary>
    public partial class Selection : Window
    {
        public Selection()
        {
            InitializeComponent();
            this.Closed += Selection_Closed;
            this.Closing += Selection_Closing;
        }
        private void Selection_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            string msg = "Do you want to close without saving?";
            MessageBoxResult result = MessageBox.Show(msg, "Jimmy Financial App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        private void Selection_Closed(object? sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            Environment.Exit(0);
        }

        private void Renting_Selected(object sender, RoutedEventArgs e)
        {
            Renting rents = new Renting();
            rents.Owner = this;
            rents.Show();
            this.Hide();
        }

        private void Buying_Selected(object sender, RoutedEventArgs e)
        {
            BuyProperty buy = new BuyProperty();
            buy.Owner = this;
            buy.Show();
            this.Hide();

        }

        private void PurchaseVechile_Selected(object sender, RoutedEventArgs e)
        {
            VehiclePurchase veh = new VehiclePurchase();
            veh.Owner = this;
            veh.Show();
            this.Hide();
        }

        private void Savings_Selected(object sender, RoutedEventArgs e)
        {
            Save sav = new Save();
            sav.Owner = this;
            sav.Show();
            this.Hide();
        }
    }
}
