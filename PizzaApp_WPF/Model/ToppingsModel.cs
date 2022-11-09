using CommunityToolkit.Mvvm.ComponentModel;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public partial class ToppingsModel : ObservableObject
    {
        public ToppingsModel(int Id, string Name, int Price, bool IsSelected)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Selected = IsSelected;
        }

        [ObservableProperty] int _id;
        [ObservableProperty] string _name;
        [ObservableProperty] int _price;
        [ObservableProperty] bool _selected;
    }
}