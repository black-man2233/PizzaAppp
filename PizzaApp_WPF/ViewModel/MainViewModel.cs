using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class MainViewModel : ObservableObject, INotifyPropertyChanged
    {
        static PizzaListModel menu = new();

        [ObservableProperty] ObservableCollection<PizzaModel>? _menuList ;
        [ObservableProperty] int _menuSelectedIndex = -1;

        [ObservableProperty] public static ObservableCollection<PizzaModel> _cartList = new();
        [ObservableProperty] int _cartSelectedIndex = -1;


        [ObservableProperty] ObservableCollection<DrinksModel> _drinks = menu.DrinksList;
        [ObservableProperty] int _drinksSelected;
        [ObservableProperty] PizzaModel _selectedPizza;


        public static string _totPrice;
        public string TotPrice
        {
            get
            {
                return _totPrice;
            }
            set
            {
                _totPrice = value;
                OnPropertyChanged("TotPrice");
            }
        }




        public static string totCalc()
        {
            var c = _cartList;
            List<int> pricesCombined = new();

            for (int i = 0; i < c.Count; i++)
            {
                pricesCombined.Add(c[i].Total);
            }
            return (pricesCombined.Sum()).ToString();

        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }));
        }


    }
}