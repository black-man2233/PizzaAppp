using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace PizzaApp_WPF.Model
{
    public class PizzaListModelModel
    {
        //stigen til Pizza.Json
        private static readonly string menuDbText = File.ReadAllText(@"C:\Users\Kevin\Source\Repos\PizzaAppp\PizzaApp_WPF\Database\PizzasDB.json");

        // Menu Database
        private protected ObservableCollection<PizzaType>? _pizzasList = JsonConvert.DeserializeObject<ObservableCollection<PizzaType>>(menuDbText);

        public ObservableCollection<PizzaType>? PizzasList { get => _pizzasList; set => _pizzasList = value; }



        ////Drinks Database
        private static readonly string DrinksDbText = File.ReadAllText(@"C:\Users\Kevin\Source\Repos\PizzaAppp\PizzaApp_WPF\Database\DrinksDB.json");

        private protected ObservableCollection<DrinksModel>? _drinksList = JsonConvert.DeserializeObject<ObservableCollection<DrinksModel>>(DrinksDbText);

        public ObservableCollection<DrinksModel>? DrinksList { get => _drinksList; set => _drinksList = value; }

    }
}

