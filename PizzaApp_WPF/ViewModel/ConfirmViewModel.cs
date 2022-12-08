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


            Text= "Lalalals asdalsdl";
        }

        #region Properties
        //Timer
        private string _text;
        private double _scrollPosition;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public double ScrollPosition
        {
            get { return _scrollPosition; }
            set
            {
                _scrollPosition = value;
                OnPropertyChanged("ScrollPosition");
            }
        }

        public void UpdateScrollPosition()
        {
            ScrollPosition += 1;
        }




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
                    CartItems.Remove(p);
        }


        public ObservableCollection<PizzaModel> psada
        { get => MainViewModel._cartList; }

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
                    CartItems.Remove(d);

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
        }

        void totCalc()
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
