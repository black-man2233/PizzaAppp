using Newtonsoft.Json;
using PizzaAppp.Classes;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace PizzaAppp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Pizzaerne> cartData;
        //stigen til Pizza.Json
        string jsonText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaAppp\Classes\Pizzas.json");

        List<Pizzaerne> cartList;

        public MainWindow()
        {
            InitializeComponent();

            Menu_Dg.Items.Clear();
            Cart_Dg.ItemsSource = cartData;

            PizzaMenu();
        }


        ///<summary>
        /// Indlæser dataen fra pizza.Json, og fylder den op i menu DataGrid
        /// </summary>
        void PizzaMenu()
        {

            // konverter JSON string til liste med Pizza 
            var menuData = JsonConvert.DeserializeObject<List<Pizzaerne>>(jsonText);

            //udfylder Menu dataGrid med Objekter fra Pizza.Json
            Menu_Dg.ItemsSource = menuData;

            cartList = menuData;
        }


        /// <summary>
        /// Double trykker på en item fra Menuen og bliver tilføjet til indkøbskurv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Dg_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // cartData.Add(cartList[Menu_Dg.SelectedIndex]);


        }
    }
}
