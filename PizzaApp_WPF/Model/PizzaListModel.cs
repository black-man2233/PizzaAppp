using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public class PizzaListModel
    {
        // Menu Database
        private static string menuDbText = File.ReadAllText(@"C:\Users\Kevin\Source\Repos\PizzaAppp\PizzaApp_WPF\Database\PizzasDB.json");

        public ObservableCollection<PizzaModel>? PizzasList = JsonConvert.DeserializeObject<ObservableCollection<PizzaModel>>(menuDbText);




        ////Drinks Database
        private static readonly string DrinksDbText = File.ReadAllText(@"C:\Users\Kevin\Source\Repos\PizzaAppp\PizzaApp_WPF\Database\DrinksDB.json");

        public ObservableCollection<DrinksModel>? DrinksList = JsonConvert.DeserializeObject<ObservableCollection<DrinksModel>>(DrinksDbText);


    }
}

