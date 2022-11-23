using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp_WPF.Model
{
    public partial class DrinksSize : ObservableObject
    {
        [ObservableProperty] string? _name;
        [ObservableProperty] int _price;
        [ObservableProperty] bool _selected;
    }
}
