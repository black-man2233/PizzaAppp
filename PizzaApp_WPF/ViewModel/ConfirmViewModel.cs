using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Utils;
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
    public partial class ConfirmViewModel : ObservableObject
    {
        //static ObservableCollection<PizzaModel> items;

        public ConfirmViewModel(ObservableCollection<PizzaModel> cart)
        {
            _pizzas.Clear();
            _drinks.Clear();

            DrinksOrPizzas(cart, _pizzas, _drinks);

            _totalPrice = MainViewModel._totPrice;
        }


        [ObservableProperty] private ObservableCollection<PizzaModel>? _cartItems = new();

        [ObservableProperty] public static ObservableCollection<PizzaModel>? _pizzas = new();

        [ObservableProperty] public static ObservableCollection<PizzaModel>? _drinks = new();

        private static void DrinksOrPizzas(ObservableCollection<PizzaModel> listOfItems, ObservableCollection<PizzaModel> pizzaHere, ObservableCollection<PizzaModel> drinksHere)
        {
            for (int i = 0; i < listOfItems.Count; i++)
            {
                if (listOfItems[i].Extras != null)
                {
                    pizzaHere.Add(listOfItems[i]);
                }
                else
                {
                    drinksHere.Add(listOfItems[i]);
                }
            }
        }

        private static string _totalPrice = "0";
        public string TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }



        public static void totCalc()
        {
            List<int> pricesCombined = new();

            if (_pizzas.Count > 0 || _drinks.Count > 0)
            {
                for (int i = 0; i < _pizzas.Count; i++)
                {
                    for (int j = 0; j < _drinks.Count; j++)
                    {
                        pricesCombined.Add(_pizzas[i].Total);

                    }

                }
            }



        }





#pragma warning disable
        public event PropertyChangedEventHandler? PropertyChanged;
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
