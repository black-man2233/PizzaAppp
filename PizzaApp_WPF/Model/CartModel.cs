using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp_WPF.Model
{
    public partial class CartModel : ObservableObject
    {
        [ObservableProperty] string? _name;
        [ObservableProperty] int _price;
        [ObservableProperty] int _total;
        [ObservableProperty] string _description;
        [ObservableProperty] ObservableCollection<ToppingsModel>? _toppings;
        [ObservableProperty] ObservableCollection<ExtrasModel>? _extras;


        public CartModel(string? name, int price, int total, string description, ObservableCollection<ToppingsModel>? toppings, ObservableCollection<ExtrasModel>? extras)
        {
            Name = name;
            Price = price;
            Total = total;
            Description = description;
            Toppings = toppings;
            Extras = extras;
        }

    }
}
