using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class ModifyViewModel : ObservableObject, INotifyPropertyChanged
    {
        public ModifyViewModel(PizzaModel __pizza)
        {
            pizza = __pizza;
            _pizzaDescription= pizza.Description;
            _toppings= pizza.Toppings;
            _extras= pizza.Extras;

        }
        [ObservableProperty] public static PizzaModel pizza;

        [ObservableProperty] string? _pizzaDescription;

        [ObservableProperty] static ObservableCollection<ToppingsModel>? _toppings;

        [ObservableProperty] public static ObservableCollection<ExtrasModel>? _extras;
    }
}

