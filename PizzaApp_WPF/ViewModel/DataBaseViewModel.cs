using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using PizzaApp_WPF.Model.Toppings;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public partial class DataBaseViewModel : ObservableObject

    {
        public DataBaseViewModel()
        {
            _pizzasList = new ObservableCollection<PizzaModel>(JsonConvert.DeserializeObject<ObservableCollection<PizzaModel>>(menuDbText));
            _drinksList = new ObservableCollection<DrinksModel>(JsonConvert.DeserializeObject<ObservableCollection<DrinksModel>>(DrinksDbText));
            _extrasList = new ObservableCollection<ExtrasModel>(JsonConvert.DeserializeObject<ObservableCollection<ExtrasModel>>(ExtrasDbText));
            _toppingsList = new ObservableCollection<ToppingsListModel>(JsonConvert.DeserializeObject<ObservableCollection<ToppingsListModel>>(ToppingsText));

        }

        //PizzaList
        private readonly string menuDbText = File.ReadAllText(@"C:\Users\Kevin\Source\Repos\PizzaAppp\PizzaApp_WPF\Database\PizzasDB.json");
        [ObservableProperty] ObservableCollection<PizzaModel>? _pizzasList;

        ////Drinks 
        private readonly string DrinksDbText = File.ReadAllText(@"C:\Users\Kevin\Source\Repos\PizzaAppp\PizzaApp_WPF\Database\DrinksDB.json");

        [ObservableProperty] ObservableCollection<DrinksModel>? _drinksList;


        ////Extras
        private readonly string ExtrasDbText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaApp_WPF\Database\ExtrasDb.json");

        [ObservableProperty] ObservableCollection<ExtrasModel>? _extrasList;
        
        ////Toppings
        private readonly string ToppingsText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaApp_WPF\Database\ToppingsDB.json");

        [ObservableProperty] ObservableCollection<ToppingsListModel>? _toppingsList;

    }
}

