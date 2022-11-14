using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{
    public partial class DrinksModel : ObservableObject
    {
        [ObservableProperty] int _id;

        [ObservableProperty] string? _name;

        [ObservableProperty] int _price;

        [ObservableProperty] ObservableCollection<ToppingsModel>? _capacity;
    }
}