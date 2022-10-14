using Newtonsoft.Json;
using PizzaAppp.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PizzaAppp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
        static int totPrice = allPrices.Sum();

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
                totPrice = allPrices.Sum();
                TotalPrice_lb.Content = $"Pris i alt er {totPrice} kr.";

            }
            else
            {
                TotalPrice_lb.Content = $"Pris i alt er {totPrice} kr.";

            }
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



        //loads a new window for the toppings

        /// <summary>
        /// Opens up The customazation window for the current pizza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cart_Dg_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModifyPizzaWindow();
        }

        void ModifyPizzaWindow()
        {
            ModifyPizzaWindow modifypizzawindow = new ModifyPizzaWindow();
            //opens  up the Topping window
            modifypizzawindow.ShowDialog();
            modifypizzawindow.TotalPris_Tb.Text = $"i alt = {totPrice}";


            //clears the default items in the Listbox, !!!IT WAS RECOMENDED FOR SOME REASON
            modifypizzawindow.Toppings_Lb.Items.Clear();

            //variable that keeps in mind which items was selected
            int cartSelectedIndex = Cart_Dg.SelectedIndex;


            //creates checkboxes for each topping for the selected pizza
            int amountOfToppings = cartData[Cart_Dg.SelectedIndex].Toppings.Count;

            for (int i = 0; i < amountOfToppings; i++)
            {
                //creates a new checkbox
                CheckBox _ToppingBox = new CheckBox();

                // Set height of the checkbox
                _ToppingBox.Height = 50;

                // Set width of the checkbox+
                _ToppingBox.Width = 100;


                _ToppingBox.Content = $"{cartData[cartSelectedIndex].Name} = {cartData[cartSelectedIndex].Toppings[cartSelectedIndex]} kr.";


                modifypizzawindow.Toppings_Lb.Items.Add(_ToppingBox);

            }

        }

    }
}
