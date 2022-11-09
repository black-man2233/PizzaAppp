using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class ModifyViewModel : ObservableObject
    {
        public ModifyViewModel(PizzaType pizza)
        {
            _pizzaDescription = pizza.Description;

            _toppings = pizza.Toppings;

        }

        [ObservableProperty] string _pizzaDescription;

        [ObservableProperty] ObservableCollection<ToppingsModel> _toppings = new();

        [ObservableProperty] int _totalPrice;


        void total()
        {
            _totalPrice = 0;
            ObservableCollection<int> allPrices = new();

            if (_toppings.Count > 0)
            {
                for (int i = 0; i < _toppings.Count; i++)
                {
                    if (_toppings[i].Selected = true)
                    {
                        allPrices.Add(_toppings[i].Price);
                    }
                }

                _totalPrice = allPrices.Sum();
            }
        }

    }
}
