using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.ViewModel
{
    public partial class ConfirmViewModel : ObservableObject
    {

        public ConfirmViewModel(ObservableCollection<PizzaModel> cart)
        {
            _cartItems = cart;
            _totalPrice = MainViewModel._totPrice;
        }


        [ObservableProperty] ObservableCollection<PizzaModel>? _cartItems = new();

        [ObservableProperty] int _totalPrice;

    }
}
