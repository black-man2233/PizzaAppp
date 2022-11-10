using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{

    public partial class PizzaModel : ObservableObject
    {

        [ObservableProperty] int _id;

        [ObservableProperty] string? _name;

        [ObservableProperty] int _price;

        [ObservableProperty] string? _description;

        [ObservableProperty] ObservableCollection<ToppingsModel>? _toppings;

        [ObservableProperty] ObservableCollection<ExtrasModel>? _extras;



        /// <summary>Initializes a new instance of the <see cref="PizzaType" /> class.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="price">The price.</param>
        /// <param name="description">The description.</param>
        /// <param name="toppings">The toppings.</param>
        /// <param name="ex">The extra toppings.</param>
        //        public PizzaModel(PizzaModel pizza)
        //        {
        //            //////var a = pizza._id;
        //            //////var b = pizza.Price;
        //            //////var c = pizza.Description;
        //            //////var d = pizza.Toppings;
        //            //////var e = pizza.Extras;

        //            Id = pizza._id;
        //            Name = pizza.Name;
        //            Price = pizza.Price;
        //            Description = pizza.Description;
        //#pragma warning disable CS8604 // Possible null reference argument.
        //            Toppings = new ObservableCollection<ToppingsModel>(collection: pizza.Toppings);
        //            Extras = new ObservableCollection<ExtrasModel>(collection: pizza.Extras);
        //#pragma warning restore CS8604 // Possible null reference argument.
        //        }

    }

}
