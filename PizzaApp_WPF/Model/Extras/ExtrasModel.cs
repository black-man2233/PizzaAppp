using CommunityToolkit.Mvvm.ComponentModel;

namespace PizzaApp_WPF.Model
{
    public partial class ExtrasModel : ObservableObject
    {
        #region Properties
        [ObservableProperty] string? _name;
        [ObservableProperty] int _price;
        [ObservableProperty] int _amount;
        #endregion

        #region Constructor
        public ExtrasModel(string? name, int price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }
        #endregion
    }
}