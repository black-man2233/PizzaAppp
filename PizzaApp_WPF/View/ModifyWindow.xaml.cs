using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
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

        public ModifyWindow()
        {
            InitializeComponent();
        }


        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox? c = sender as CheckBox;

            if (c != null)
            {
                ToppingsModel? t = c.Tag as ToppingsModel;

                if (t != null)
                {
                    MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected = false;
                    MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Name = "False";
                    MessageBox.Show($"{MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected}");

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
                    MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected = true;
                    MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Name = "true";
                    MessageBox.Show($"{MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected}");

                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
