using CommunityToolkit.Mvvm.ComponentModel;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public partial class ToppingsModel : ObservableObject
    {
        [ObservableProperty] string _name;
        [ObservableProperty] bool _selected;

        public ToppingsModel(string name, bool selected)
        {
            this._name = name;
            this._selected = selected;
        }

    }
}