using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Utils;
using PizzaApp_WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;



namespace PizzaApp_WPF.ViewModel
{
    public partial class ConfirmViewModel : ObservableObject
    {
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



        private string _totalPrice;
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
            //var c = _cartList;
            //List<int> pricesCombined = new();

            //for (int i = 0; i < c.Count; i++)
            //{
            //    pricesCombined.Add(c[i].Total);
            //}
            //return pricesCombined.Sum();

        }




#pragma warning disable
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
