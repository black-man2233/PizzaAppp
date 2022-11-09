using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{

    public partial class PizzaType : ObservableObject
    {

        [ObservableProperty] int _id;

        [ObservableProperty] private string _name;

        [ObservableProperty] int _price;

        [ObservableProperty] string _description;

        [ObservableProperty] ObservableCollection<ToppingsModel>? _toppings;



#pragma warning disable
        /// <summary>Initializes a new instance of the <see cref="PizzaType" /> class.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="price">The price.</param>
        /// <param name="description">The description.</param>
        /// <param name="toppings">The toppings.</param>
        public PizzaType(int id, string? name, int price, string? description, ObservableCollection<ToppingsModel>? toppings)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Toppings = new ObservableCollection<ToppingsModel>(toppings);
        }
#pragma warning restore

    }

}
