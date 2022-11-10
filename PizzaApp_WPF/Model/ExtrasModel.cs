using CommunityToolkit.Mvvm.ComponentModel;

namespace PizzaApp_WPF.Model
{
    public partial class ExtrasModel : ObservableObject
    {
        [ObservableProperty] int _id;
        [ObservableProperty] string? _name;
        [ObservableProperty] int _price;
        [ObservableProperty] int _amount;
    }
}