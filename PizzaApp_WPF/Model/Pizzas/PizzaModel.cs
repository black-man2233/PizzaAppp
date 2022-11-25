using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Utils.Url;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{

    public partial class PizzaModel : ObservableObject
    {
#pragma warning disable
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


        public PizzaModel Clone()
        {
            PizzaModel _pizzamodel = (PizzaModel)MemberwiseClone();
            
            //toppings
            ObservableCollection<ToppingsModel> toppings = new();
            for (int i = 0; i < toppings.Count; i++)
            {
                toppings[i].Name = _pizzamodel.Toppings[i].Name;
            }
            _pizzamodel.Toppings = toppings;


            //Extras
            ObservableCollection<ExtrasModel> extras = new();
            for (int i = 0; i < extras.Count; i++)
            {
                extras[i].Name = _pizzamodel.Extras[i].Name;
            }
            _pizzamodel.Extras = extras;


            return _pizzamodel;

        }


    }
}
