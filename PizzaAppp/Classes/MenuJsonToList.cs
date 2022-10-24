using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace PizzaAppp.Classes
{
    public static class MenuJsonToList
    {
        //stigen til Pizza.Json
        private static readonly string jsonText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaAppp\Classes\Pizzas.json");

        // konverter JSON string til liste med Pizza 
        private static ObservableCollection<PizzasMenu> menuData = JsonConvert.DeserializeObject<ObservableCollection<PizzasMenu>>(jsonText);

        public static ObservableCollection<PizzasMenu> MenuData
        {
            get
            {
                return menuData;
            }
            private set {; }
        }
    }
}
