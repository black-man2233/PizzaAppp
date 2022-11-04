using PizzaApp_WPF.Class;
using PizzaApp_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

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
            confirm.ShowDialog();
        }


        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MainViewModel._cartList.Count > 0)
            {

                if (sender is Button button)
                {
                    PizzaType? pizza = MainViewModel._cartList[MainViewModel._cartSelectedIndex] as PizzaType;

                    if (pizza != null)
                    {
                        ModifyWindow modifyWindow = new ModifyWindow(MainViewModel._cartList[MainViewModel._cartSelectedIndex]);
                        modifyWindow.ShowDialog();

                    }
                }
            }
            else
            {
                MessageBox.Show("Ingen Valgte Pizza fra Kurven", "How");

            }
        }
    }
}
