using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{

    public partial class PizzaModel : ObservableObject
    {

        [ObservableProperty] string? _name;

        [ObservableProperty] int _price;

        [ObservableProperty] string? _description;

        [ObservableProperty] int _total;

        [ObservableProperty] ObservableCollection<ToppingsModel>? _toppings;

        [ObservableProperty] ObservableCollection<ExtrasModel>? _extras;


        /// <summary>Initializes a new instance of the <see cref="PizzaType" /> class.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="price">The price.</param>
        /// <param name="description">The description.</param>
        /// <param name="toppings">The toppings.</param>
        /// <param name="ex">The extra toppings.</param>
        public PizzaModel(string name, int price, int total, string description, ObservableCollection<ToppingsModel> toppings, ObservableCollection<ExtrasModel> extras)
        {
            this.Name = name;
            this.Price = price;
            this.Total = total;
            this.Description = description;
#pragma warning disable CS8604 // Possible null reference argument.

            this.Toppings = toppings;
            this.Extras = extras;
        }

    }

}
