using System.Windows;
using static PizzaAppp.MainWindow;

namespace PizzaAppp
{
    /// <summary>
    /// Interaction logic for ModifyPizzaWindow.xaml
    /// </summary>
    public partial class ModifyPizzaWindow : Window
    {
        public ModifyPizzaWindow()
        {
            InitializeComponent();

            ToppingLoader();
        }

        void ToppingLoader()
        {
            MainWindow aa = new MainWindow();
            var a = menuData[GetCartDg.SelectedIndex].Toppings.Count;


            MessageBox.Show($"{a}");

            //for (int i = 0; i < MainWindow.cartData[1].Toppings.Count; i++)
            //{


            //}

            //cartData.Add(newItem);

        }

        private void CheckListen_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
