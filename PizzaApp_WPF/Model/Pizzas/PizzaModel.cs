using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{

    public partial class PizzaModel : ObservableObject
    {
        #region Properties
        [ObservableProperty] ObservableCollection<ToppingsModel>? _toppings;
        [ObservableProperty] ObservableCollection<ExtrasModel>? _extras;
        [ObservableProperty] string? _description;
        [ObservableProperty] string? _name;
        [ObservableProperty] int _total;
        [ObservableProperty] int _price;
        #endregion


        #region Constructors
        public PizzaModel(string? name, int price, int total, string? description, ObservableCollection<ToppingsModel>? toppings, ObservableCollection<ExtrasModel>? extras)
        {
            Name = new(name);

            Price = price;

            Total = total;

            Description = Description != null ? (new(description)) : null;

            Toppings = toppings != null ? (new(toppings)) : null;

            Extras = extras != null ? (new(extras)) : null;
        }

        #endregion
    }
}
