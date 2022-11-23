using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model.Pizzas
{
    public partial class PIzzaMenuModel : ObservableObject
    {
        [ObservableProperty] string? _name;
        [ObservableProperty] int price;
        [ObservableProperty] ObservableCollection<ToppingsModel>? toppings;
        [ObservableProperty] ObservableCollection<ExtrasModel>? extras;


        public PIzzaMenuModel(string name, int price, ObservableCollection<ToppingsModel>? toppings, ObservableCollection<ExtrasModel>? extras)
        {
            Name = name;
            Price = price;
            Toppings = new(toppings);
            Extras = new(extras);
        }

    }
}
