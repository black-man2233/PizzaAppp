using Newtonsoft.Json;
using PizzaAppp.Classes;
using System.Collections.ObjectModel;
using System.IO;
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
        }


        //stigen til Pizza.Json
        static string jsonText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaAppp\Classes\Pizzas.json");

        // konverter JSON string til liste med Pizza 
        ObservableCollection<PizzaerneMenu> menuData = JsonConvert.DeserializeObject<ObservableCollection<PizzaerneMenu>>(jsonText);

        //lisen som husker på de vaglte pizzaere
        ObservableCollection<ShoppingCart> cartData = new ObservableCollection<ShoppingCart>();


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

        }

        void TotPrice()
        {
            for (int i = 0; i < menuData.Count - 1; i++)
            {
                int total = Sum(menuData[i].Price);
            }

            foreach (var item in menuData[i].Price)
            {

            }



        }


        /// <summary>
        /// Double trykker på en item fra Menuen og bliver tilføjet til indkøbskurv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Dg_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ShoppingCart newItem = new ShoppingCart((menuData[Menu_Dg.SelectedIndex].Name).ToString(), (menuData[Menu_Dg.SelectedIndex].Price));
            cartData.Add(newItem);

        }
    }
}
