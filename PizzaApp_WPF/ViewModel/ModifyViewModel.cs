using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class ModifyViewModel : ObservableObject, INotifyPropertyChanged
    {
        public ModifyViewModel()
        {
            _pizzaDescription = new(MainViewModel._selectedPizza.Description);
            _toppings = new(MainViewModel._selectedPizza.Toppings);
            _extras = new(MainViewModel._selectedPizza.Extras);
            _totalPrice = MainViewModel._selectedPizza.Total;

        }

        [ObservableProperty] string? _pizzaDescription;

        [ObservableProperty] static ObservableCollection<ToppingsModel>? _toppings = new();

        [ObservableProperty] public static ObservableCollection<ExtrasModel>? _extras = new();

        [ObservableProperty] public static int _totalPrice;


    }
}

