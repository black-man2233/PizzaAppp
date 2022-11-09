using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System.Windows;

namespace PizzaApp_WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToPayment_bt_Click(object sender, RoutedEventArgs e)
        {
            ConfirmWindow confirm = new();
            _ = confirm.ShowDialog();
        }


        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MainViewModel._cartList.Count > 0)
            {

                if (MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings is not null)
                {
                    ModifyWindow modifyWindow = new(MainViewModel._cartList[MainViewModel._cartSelectedIndex]);
                    _ = modifyWindow.ShowDialog();
                }
                else
                {
                    _ = MessageBox.Show("Dette Element kan ikke modificeres", "Hov");
                }
            }
            else
            {
                _ = MessageBox.Show("Ingen Valgte Pizza fra Kurven", "How");
            }

        }

        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DrinksModel d = MainViewModel._drinks[MainViewModel._drinksSelected];
            if (MainViewModel._drinksSelected >= 0)
            {
                MainViewModel._cartList.Add(new PizzaType(d.Id, d.Name, d.Price, d.Name, d.Capacity));
            }
        }
    }
}
