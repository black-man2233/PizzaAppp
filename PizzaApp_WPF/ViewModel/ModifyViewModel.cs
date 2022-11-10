using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class ModifyViewModel : ObservableObject
    {
        public ModifyViewModel()
        {
            try
            {

                _pizzaDescription = MainViewModel._selectedPizza.Description;
                _toppings = MainViewModel._selectedPizza.Toppings;
                _extras = MainViewModel._selectedPizza.Extras;


            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [ObservableProperty] string _pizzaDescription = string.Empty;

        [ObservableProperty] ObservableCollection<ToppingsModel> _toppings = new();

        [ObservableProperty] ObservableCollection<ExtrasModel> _extras = new();

        [ObservableProperty] int _totalPrice;







    }
}

