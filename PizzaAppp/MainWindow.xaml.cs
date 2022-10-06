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


        public MainWindow()
        {

            InitializeComponent();

            PizzaMenu();
            CartF();

        }

        /// <summary>
        /// Indlæser dataen fra pizza.Json, og fylder den op i menu DataGrid
        /// </summary>
        void PizzaMenu()
        {

            //stigen til Pizza.Json
            string jsonText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaAppp\Classes\Pizzas.json");

            // konverter JSON string til liste med Person 
            var data = JsonConvert.DeserializeObject<List<Pizzaerne>>(jsonText);

            //udfylder Menu dataGrid med Objekter fra Pizza.Json

            Menu_Dg.Items.Clear();
            Menu_Dg.ItemsSource = data;

        }

        void CartF()
        {
            Cart_lB.Items.Clear();
            Cart_lB.ItemsSource = data;

        }

        private void Menu_Dg_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            foreach (Pizzaerne item in Menu_Dg.SelectedItems)
            {

                Cart_lB.Items.Add(item);
            }

        }
    }
}
