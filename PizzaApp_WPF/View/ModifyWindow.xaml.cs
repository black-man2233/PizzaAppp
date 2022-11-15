using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace PizzaApp_WPF.View
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
#pragma warning disable

        public ModifyWindow(PizzaModel pizza)
        {
            InitializeComponent();
            ModifyViewModel viewModel = new ModifyViewModel(pizza);
            this.DataContext = viewModel;

            ModifyViewModel.pizza.Total = (EditModifiedPrice()) + (ModifyViewModel.pizza.Price);

        }

        //checkBoxes
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox? c = sender as CheckBox;
            if (c != null)
            {
                ToppingsModel? t = c.Tag as ToppingsModel;

                if (t != null)
                {
                    //MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected = false;
                    //MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Name = "False";
                    //MessageBox.Show($"{MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected}");

                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox? c = sender as CheckBox;

            if (c != null)
            {
                ToppingsModel? t = c.Tag as ToppingsModel;

                if (t != null)
                {
                    //MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected = true;
                    //MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Name = "true";
                    //MessageBox.Show($"{MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected}");

                }
            }

        }

        private void ConfirmButton(object sender, RoutedEventArgs e)
        {
            Close();
        }



        //Buttons
        private void Increase_btClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            ExtrasModel extra = b.Tag as ExtrasModel;

            if (extra.Amount < 30)
            {
                extra.Amount++;

                ModifyViewModel.pizza.Total = (EditModifiedPrice()) + (ModifyViewModel.pizza.Price);

            }
            else
            {
                MessageBox.Show("Du kan ikke få mere end 30");

            }
        }
        private void Decrease_btClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            ExtrasModel extra = b.Tag as ExtrasModel;
            if (extra.Amount > 0)
            {
                extra.Amount--;
                ModifyViewModel.pizza.Total = (EditModifiedPrice()) + (ModifyViewModel.pizza.Price);

            }
            else
            {
                MessageBox.Show("Du kan ikke få mindre end nul");
            }

        }
        static int EditModifiedPrice()
        {
            var extras = ModifyViewModel._extras;

            ObservableCollection<int> allPrices = new();


            for (int i = 0; i < extras.Count; i++)
            {
                if (ModifyViewModel._extras[i].Amount > 0)
                {
                    allPrices.Add((extras[i].Amount) * (extras[i].Price));
                }
            }
            return allPrices.Sum();
        }
    }
}
