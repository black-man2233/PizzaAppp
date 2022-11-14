using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class MainViewModel : ObservableObject, INotifyPropertyChanged
    {
        static PizzaListModel menu = new();

        [ObservableProperty] ObservableCollection<PizzaModel>? _menuList = menu.PizzasList;
        [ObservableProperty] int _menuSelectedIndex = -1;

        [ObservableProperty] public static ObservableCollection<PizzaModel> _cartList = new();
        [ObservableProperty] public static int _cartSelectedIndex = -1;


        [ObservableProperty] ObservableCollection<DrinksModel> _drinks = menu.DrinksList;
        [ObservableProperty] ObservableCollection<ToppingsModel> _drinkSize;
        [ObservableProperty] int _drinksSelected;
        [ObservableProperty] PizzaModel _selectedPizza;

        [ObservableProperty] public static int _totPrice;

        public void totCalc()
        {
            var c = _cartList;
            List<int> pricesCombined = new();

            for (int i = 0; i < c.Count; i++)
            {
                pricesCombined.Add(c[i].Total);
            }
            _totPrice = pricesCombined.Sum();

        }

    }
}