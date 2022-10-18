using Newtonsoft.Json;
using PizzaAppp.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace PizzaAppp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static int IndexOfSelctedInCart;

        public MainWindow()
        {

            InitializeComponent();

            //udfylder gridene op med listen af pizzaer
            MenuAndCart();

        }

        //stigen til Pizza.Json
        private static string jsonText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaAppp\Classes\Pizzas.json");

        // konverter JSON string til liste med Pizza 
        public static ObservableCollection<PizzasMenu> menuData = JsonConvert.DeserializeObject<ObservableCollection<PizzasMenu>>(jsonText);

        //lisen som husker på de vaglte pizzaere
        public static ObservableCollection<PizzasMenu> cartData = new ObservableCollection<PizzasMenu>();

        //listen med alle priser
        static List<int> allPrices = new List<int>();
        private static int _totPrice = allPrices.Sum();


        /// <summary>
        /// Clears and fills up menu with a list of the pizzas
        /// </summary>
        void MenuAndCart()
        {
            //menuData.Add(new PizzasMenu(1,"Hello", 1));
            Menu_Dg.Items.Clear();
            Cart_Dg.Items.Clear();
            Menu_Dg.ItemsSource = menuData;
            Cart_Dg.ItemsSource = cartData;
            PriceCalc();
        }

        /// <summary>
        /// Calcutates the total price of all items in the shopping cart
        /// </summary>
        /// <returns></returns>
        public void PriceCalc()
        {
            if (cartData.Count > 0)
            {
                // add the price of the Selected item from the Menu
                allPrices.Add(menuData[Menu_Dg.SelectedIndex].Price);
                _totPrice = allPrices.Sum();
                TpHome.Content = $"Pris i alt er {_totPrice} kr.";

            }
            else
            {
                TpHome.Content = $"Pris i alt er {_totPrice} kr.";

            }
        }


        /// <summary>
        /// Double trykker på en item fra Menuen og bliver tilføjet til indkøbskurv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Dg_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AddToCart();
            PriceCalc();
        }

        /// <summary>
        /// Adds the Selected item from the Menu to the Cart
        /// </summary>
        void AddToCart()
        {
            //gets the index of the selected item
            //gets the items properties and addes it to the cart
            cartData.Add(menuData[Menu_Dg.SelectedIndex]);

        }

        //Gets the index of the selected item from the cart

        Window tet = MainWindow.Hide();
        static void MainShow()
        {
            MainWindow.ShowActivatedProperty();
        }

        /// <summary>
        /// Opens up The customazation window for the current pizza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cart_Dg_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            IndexOfSelctedInCart = Convert.ToInt32(Cart_Dg.SelectedIndex);
            ModifyPizzaWindow modifypizzawindow = new ModifyPizzaWindow();
            //opens  up the Topping window
            modifypizzawindow.ShowDialog();

        }




    }
}
