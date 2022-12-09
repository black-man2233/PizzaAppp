using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Utils;
using PizzaApp_WPF.Model;
using PizzaApp_WPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PizzaApp_WPF.ViewModel
{
    public partial class ConfirmViewModel : ObservableObject, INotifyPropertyChanged
    {
        //static ObservableCollection<PizzaModel> items;

        public ConfirmViewModel(ObservableCollection<PizzaModel> cart)
        {
            _cartItems.Clear();
            _pizzas.Clear();
            _drinks.Clear();

            _cartItems = cart;

            DrinksOrPizzas();
            BackButtonCommand = new Command.RelayCommand.RelayCommand(GoBack, CanGoBack);
            DeletePizzaCommand = new Command.RelayCommand.RelayCommand(DeletePizza, CanDeletePizza);
            DeleteDrinksCommand = new Command.RelayCommand.RelayCommand(DeleteDrink, CanDeleteDrinks);
            totCalc();
        }

        #region Properties
        //CartItems
        private ObservableCollection<PizzaModel>? _cartItems = new();
        public ObservableCollection<PizzaModel>? CartItems
        {
            get
            {
                return _cartItems;
            }
            set
            {
                _cartItems = value;
                OnPropertyChanged("CartItems");
            }
        }

        //Pizzas
        private ObservableCollection<PizzaModel> _pizzas = new();
        public ObservableCollection<PizzaModel> Pizzas
        {
            get
            {
                return _pizzas;
            }
            set
            {
                _pizzas = value;
                OnPropertyChanged("Pizzas");
            }
        }

        //Drinks
        private ObservableCollection<PizzaModel> _drinks = new();
        public ObservableCollection<PizzaModel> Drinks
        {
            get
            {
                return _drinks;
            }
            set
            {
                _drinks = value;
                OnPropertyChanged("Drinks");
            }
        }

        //Total Price
        private static string _totalPrice;
        public string TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        #endregion


        #region ICommands  
        public ICommand DeletePizzaCommand { get; set; }
        public ICommand DeleteDrinksCommand { get; set; }
        public ICommand BackButtonCommand { get; set; }
        public ICommand GoToConfirmCommand { get; set; }
        #endregion


        #region Event Method

        //Delete Pizzas
        private bool CanDeletePizza(object value)
        {
            if (Pizzas is not null || Pizzas.Count > 0)
                return true;
            else
                return false;
        }
        private void DeletePizza(Object value)
        {
            if (value is StackPanel s)
                if (s.Tag is PizzaModel p)
                {
                    CartItems.Remove(p);
                    Pizzas.Remove(p);
                }

            totCalc();
        }

        //Delete Drinks
        private bool CanDeleteDrinks(object value)
        {
            if (Drinks is not null || Drinks.Count > 0)
                return true;
            else
                return false;
        }
        private void DeleteDrink(Object value)
        {
            if (value is StackPanel s)
                if (s.Tag is PizzaModel d)
                {
                    CartItems.Remove(d);
                    Drinks.Remove(d);
                }

            totCalc();
        }

        //Back Button
        private bool CanGoBack(object value)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void GoBack(Object value)
        {
            try
            {
                Window? wnd = value as Window;
                wnd.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Method
        private void DrinksOrPizzas()
        {
            for (int i = 0; i < _cartItems.Count; i++)
                if (_cartItems[i].Extras != null)
                    _pizzas.Add(_cartItems[i]);
                else
                    _drinks.Add(_cartItems[i]);

            totCalc();
        }

        void totCalc()
        {
            List<int> _drinksPrices = new();
            List<int> _pizzaPrices = new();
            int total = 0;
            if (Drinks.Count > 0)
                for (int i = 0; i < Drinks.Count; i++)
                    _drinksPrices.Add(Drinks[i].Total);

            if (Pizzas.Count > 0)
                for (int i = 0; i < Pizzas.Count; i++)
                    _pizzaPrices.Add(Pizzas[i].Total);

            if (_drinksPrices is not null && _pizzas is not null)
                total = (_drinksPrices.Sum() + _pizzaPrices.Sum());

            TotalPrice = total.ToString();
        }
        #endregion

        #region PropertyChanged
#pragma warning disable
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
