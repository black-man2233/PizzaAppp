using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{
    public partial class DrinksModel : ObservableObject
    {
        #region Propperties
        [ObservableProperty] string? _name;
        [ObservableProperty] int _price;
        [ObservableProperty] ObservableCollection<DrinksSize>? _capacity;
        #endregion

        #region Constructor
        public DrinksModel(string? name, int price, ObservableCollection<DrinksSize>? capacity)
        {
            Name = name;
            Price = price;
            Capacity = capacity;
        }
        #endregion

    }
}