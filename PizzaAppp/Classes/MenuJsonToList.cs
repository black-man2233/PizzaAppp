using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace PizzaAppp.Classes
{
    public partial class MenuJsonToList : ObservableObject
    {
        //stigen til Pizza.Json
        private static readonly string jsonText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaApp\PizzaAppp\Database\Pizzas.json");

        // konverter JSON string til liste med Pizza 
        //[ObservableProperty]
        public static ObservableCollection<PizzaType> menuData = JsonConvert.DeserializeObject<ObservableCollection<PizzaType>>(jsonText);

    }
}
