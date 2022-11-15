using CommunityToolkit.Mvvm.ComponentModel;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public partial class ToppingsModel : ObservableObject
    {
        public ToppingsModel(string Name, int Price, bool IsSelected)
        {
            this.Name = Name;
            this.Price = Price;
            this.Selected = IsSelected;
        }

        [ObservableProperty] string _name;
        [ObservableProperty] int _price;
        [ObservableProperty] bool _selected;
    }
}