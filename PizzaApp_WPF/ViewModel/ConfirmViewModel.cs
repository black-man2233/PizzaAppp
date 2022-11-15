using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace PizzaApp_WPF.ViewModel
{
    public partial class ConfirmViewModel : ObservableObject
    {

        public ConfirmViewModel(ObservableCollection<PizzaModel> cart)
        {

            MainViewModel vm = new()
            {
                CartList = cart
            };

            _pizzas.Clear();
            _drinks.Clear();
            DrinksOrPizzas(cart, _pizzas, _drinks);

            _totalPrice = vm.TotPrice;
        }


        [ObservableProperty] private ObservableCollection<PizzaModel>? _cartItems = new();

        [ObservableProperty] public static ObservableCollection<PizzaModel>? _pizzas = new();

        [ObservableProperty] public static ObservableCollection<PizzaModel>? _drinks = new();

        [ObservableProperty] private string? _whatSize;

        private static void DrinksOrPizzas(ObservableCollection<PizzaModel> listOfItems, ObservableCollection<PizzaModel> pizzaHere, ObservableCollection<PizzaModel> drinksHere)
        {
            for (int i = 0; i < listOfItems.Count; i++)
            {
                if (listOfItems[i].Extras != null)
                {
                    pizzaHere.Add(listOfItems[i]);
                }
                else
                {
                    drinksHere.Add(listOfItems[i]);
                }
            }
        }

        

        [ObservableProperty] private int _totalPrice;

    }
}
