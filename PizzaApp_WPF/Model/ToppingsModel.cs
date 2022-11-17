using CommunityToolkit.Mvvm.ComponentModel;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public partial class ToppingsModel : ObservableObject
    {
        [ObservableProperty] string _name;
        [ObservableProperty] int _price;
        [ObservableProperty] bool _selected;
    }
}