using Newtonsoft.Json;
using PizzaAppp.Classes;
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
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            //Generer Id til pizzaerne så man kan ved hvilken man leder efter
            IdGenerator();
            //udfylder gridene op med listen af pizzaer
            MenuAndCart();


            GetCartDg = Cart_Dg;



        }

        //stigen til Pizza.Json
        private static string jsonText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaAppp\Classes\Pizzas.json");

        // konverter JSON string til liste med Pizza 
        public static ObservableCollection<PizzaerneMenu> menuData = JsonConvert.DeserializeObject<ObservableCollection<PizzaerneMenu>>(jsonText);

        //lisen som husker på de vaglte pizzaere
        public static ObservableCollection<ShoppingCart> cartData = new ObservableCollection<ShoppingCart>();


        /// <summary>
        /// Generates an Id number for evey pizza on the menu
        /// </summary>
        void IdGenerator()
        {
            for (int amountOfPizzas = 0; amountOfPizzas < menuData.Count - 1;)
            {
                for (int indexOfPizza = 1; indexOfPizza < menuData.Count; indexOfPizza++)
                {
                    menuData[amountOfPizzas].Id = indexOfPizza;
                    amountOfPizzas++;
                }
            }

        }

        /// <summary>
        /// Clears and fills up menu with a list of the pizzas
        /// </summary>
        void MenuAndCart()
        {
            //menuData.Add(new PizzaerneMenu(1,"Hello", 1));
            Menu_Dg.Items.Clear();
            Cart_Dg.Items.Clear();
            Menu_Dg.ItemsSource = menuData;
            Cart_Dg.ItemsSource = cartData;


            TotPrice();


        }

        /// <summary>
        /// Calcutates the total price of all items in the shopping cart
        /// </summary>
        /// <returns></returns>
        public void TotPrice()
        {
            List<int> allPrices = new List<int>();
            if (cartData.Count > 0)
            {
                for (int i = 0; i < cartData.Count; i++)
                {
                    allPrices.Add(cartData[i].Price);
                }

                TotalPrice_lb.Content = $"Pris i alt er {allPrices.Sum()} kr.";


            }
            else
            {
                TotalPrice_lb.Content = $"Pris i alt er {allPrices.Sum()} kr.";

            }
        }

        /// <summary>
        /// Adds the Selected item from the Menu to the Cart
        /// </summary>
        void AddToCart()
        {
            ShoppingCart newItem = new ShoppingCart((menuData[Menu_Dg.SelectedIndex].Name).ToString(), (menuData[Menu_Dg.SelectedIndex].Price));
            cartData.Add(newItem);

        }

        /// <summary>
        /// Double trykker på en item fra Menuen og bliver tilføjet til indkøbskurv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Dg_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AddToCart();
            TotPrice();
        }


        /// <summary>
        /// Opens up The customazation window for the current pizza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cart_Dg_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ModifyPizzaWindow customizeThisPizza = new ModifyPizzaWindow();

            customizeThisPizza.ShowDialog();



        }
    }
}
