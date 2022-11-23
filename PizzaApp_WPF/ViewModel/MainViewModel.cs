using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaApp_WPF.Command;
using PizzaApp_WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class MainViewModel : ObservableObject, INotifyPropertyChanged
    {
        #region Contstructor
        public MainViewModel()
        {
            #region Data
            DataBaseViewModel menu = new();
            for (int i = 0; i < menu.PizzasList.Count; i++)
            {
                var p = menu.PizzasList[i];
                _menuList.Add(new PizzaModel(p.Name, p.Price, p.Total, p.Description, p.Toppings, p.Extras));
            }

            for (int i = 0; i < menu.DrinksList.Count; i++)
            {
                var d = menu.DrinksList[i];
                _drinks.Add(new DrinksModel(d.Name, d.Price, d.Capacity));
            }

            for (int i = 0; i < menu.ExtrasList.Count; i++)
            {
                var e = menu.ExtrasList[i];
                Extras.Add(new ExtrasModel(e.Name, e.Price, e.Amount));
            }
            #endregion


            //#region Commands initialised
            //AddToCart = new Command.RelayCommand(CanAdd, CanEdit);
            //#endregion


        }
        #endregion

        #region Properties
        #region Menu
        [ObservableProperty] ObservableCollection<PizzaModel>? _menuList = new();
        [ObservableProperty] ObservableCollection<ExtrasModel>? _extras = new();
        [ObservableProperty] int _menuSelectedIndex = -1;
        [ObservableProperty] PizzaModel _menuSelectedValue;
        #endregion

        #region Drinks
        [ObservableProperty] ObservableCollection<DrinksModel> _drinks = new();
        [ObservableProperty] int _drinksSelected;
        [ObservableProperty] PizzaModel _selectedPizza;
        #endregion

        #region Cart
        [ObservableProperty] public static ObservableCollection<PizzaModel> _cartList = new();
        [ObservableProperty] public static PizzaModel _cartSelectedItem;
        [ObservableProperty] int _cartSelectedIndex = -1;
        #endregion

        #region buton   
        private bool _isButtonClicked;
        public bool IsButtonClicked
        {
            get { return _isButtonClicked; }
            set { SetProperty(ref _isButtonClicked, value); }
        }
        #endregion
        #endregion


        #region ICommands  

        public ICommand AddToCart { get; set; }
        public ICommand RemoveFromCart { get; set; }
        public ICommand CustomiseFromCart { get; set; }
        public ICommand GoToPayment { get; set; }
        #endregion

        #region Event Method        

        private void CanAdd(object value)
        {
            IsButtonClicked = true;
        }



        private void AddToCartFromMenu()
        {

        }


        private bool CanEdit(object value)
        {
            try
            {

                if (_cartSelectedItem.Extras is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
        #endregion













        public static string _totPrice;
        public string TotPrice
        {
            get => _totPrice;

            set { _totPrice = value; OnPropertyChanged("TotPrice"); }
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