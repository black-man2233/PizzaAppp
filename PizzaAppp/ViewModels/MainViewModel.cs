using CommunityToolkit.Mvvm.ComponentModel;
using PizzaAppp.Classes;
using System.Collections.ObjectModel;

namespace PizzaAppp.ViewModels
{

    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<PizzaType> menu = PizzaAppp.Classes.MenuJsonToList.menuList;

    }
}
