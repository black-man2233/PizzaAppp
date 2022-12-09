
using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using PizzaApp_WPF.Model.Toppings;
using PizzaApp_WPF.View;
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
    /// <summary>
    ///   <br />
    /// </summary>
    public partial class MainViewModel : ObservableObject, INotifyPropertyChanged
    {
        #region Contstructor
        public MainViewModel()
        {
            #region Data
            DataBaseViewModel menu = new();

            for (int i = 0; i < menu.ExtrasList.Count; i++)
                ExtrasList.Add((menu.ExtrasList[i].Clone()) as ExtrasModel);

            for (int i = 0; i < menu.PizzasList.Count; i++)
                _menuList.Add(menu.PizzasList[i].Clone() as PizzaModel);

            for (int i = 0; i < menu.DrinksList.Count; i++)
                _drinksList.Add(menu.DrinksList[i]);

            for (int i = 0; i < menu.ToppingsList.Count; i++)
                ToppingsList.Add(menu.ToppingsList[i]);
            #endregion

            #region Commands initialised
            ModifyFromCartCommand = new Command.RelayCommand.RelayCommand(ModifyFromCart, CanModiFy);
            RemoveFromCartCommand = new Command.RelayCommand.RelayCommand(RemoveFromCart, CanRemove);
            AddToCartCommand = new Command.RelayCommand.RelayCommand(AddToCart, CanAdd);
            GoToConfirmCommand = new Command.RelayCommand.RelayCommand(GoToConfirm, CanGoToConfirm);
            #endregion
        }
        #endregion

        #region Properties
        //PizzaList
        private ObservableCollection<PizzaModel> _menuList = new();
        public ObservableCollection<PizzaModel> MenuList
        {
            get => _menuList;
            set
            {
                _menuList = value;
                OnPropertyChanged("MenuList");
            }
        }

        private int _menuSelectedIndex;
        public int MenuSelectedIndex
        {
            get => _menuSelectedIndex;
            set
            {
                _menuSelectedIndex = value;
                OnPropertyChanged("MenuSelectedIndex");
            }
        }

        private PizzaModel _menuSelectedItem;
        public PizzaModel MenuSelectedItem
        {
            get => _menuSelectedItem;
            set
            {
                _menuSelectedItem = value;
                OnPropertyChanged("MenuSelectedItem");
            }
        }

        //Toppings
        ObservableCollection<ToppingsListModel> ToppingsList { get; set; } = new();

        //Extras
        ObservableCollection<ExtrasModel> ExtrasList { get; set; } = new();

        //DrinksList
        private ObservableCollection<DrinksModel> _drinksList = new();
        public ObservableCollection<DrinksModel> DrinksList
        {
            get => _drinksList;
            set
            {
                _drinksList = value;
                OnPropertyChanged("DrinksList");
            }
        }


        //cart
        [ObservableProperty] public ObservableCollection<PizzaModel> _cartList = new();

        private PizzaModel _cartSelectedItem;
        public PizzaModel CartSelectedItem
        {
            get => _cartSelectedItem;
            set
            {
                _cartSelectedItem = value;
                OnPropertyChanged("CartSelectedItem");
            }
        }

        public int CartSelectedIndex { get; set; } = -1;

        //TotalPrice
        public string _totPrice;
        public string TotPrice
        {
            get => _totPrice;

            set { _totPrice = value; OnPropertyChanged("TotPrice"); }
        }

        //ButtonCLicked
        private bool _isButtonClicked;
        public bool IsButtonClicked
        {
            get => _isButtonClicked;
            set { SetProperty(ref _isButtonClicked, value); }
        }

        #endregion

        #region ICommands  
        public ICommand AddToCartCommand { get; set; }
        public ICommand RemoveFromCartCommand { get; set; }
        public ICommand ModifyFromCartCommand { get; set; }
        public ICommand GoToConfirmCommand { get; set; }

        #endregion

        #region Event Method        

        //Add to cart
        /// <summary>Determines whether this instance can add the specified value.</summary>
        /// <returns>
        ///   <c>true</c> if this instance can add the specified value; otherwise, <c>false</c>.</returns>
        private bool CanAdd(object value)
        {
            if (MenuSelectedIndex < -1)
                return false;
            else
                return true;
        }
        private void AddToCart(object value)
        {
            if (MenuSelectedItem is not null)
            {
                IsButtonClicked = false;

                //Clones the selected Pizza
                if (MenuSelectedItem.Clone() is PizzaModel pizza)
                    if (MenuSelectedItem.ID.ToString() is not null)
                    {
                        var _toppingslist = (ToppingsList[MenuSelectedItem.ID - 1].Toppings);
                        pizza.Toppings = new();

                        foreach (var item in _toppingslist)
                            pizza.Toppings.Add((ToppingsModel)item.Clone());

                        pizza.Extras = new();
                        foreach (var item in ExtrasList)
                            pizza.Extras.Add(item.Clone() as ExtrasModel);

                        _cartList.Add(pizza.Clone() as PizzaModel);
                    }
                totCalc();

            }
            else
                MessageBox.Show($@"Vælge venligste et element fra Pizza Menu ");
        }

        //Removes items from cart
        /// <summary>Determines whether this instance can remove the specified value.</summary>
        /// <returns>
        ///   <c>true</c> if this instance can remove the specified value; otherwise, <c>false</c>.</returns>
        private bool CanRemove(object value)
        {
            if (CartSelectedIndex < -1)
                return false;
            else
                return true;
        }
        private void RemoveFromCart(object value)
        {
            if (CartSelectedItem is not null)
            {
                IsButtonClicked = false;
                _cartList.Remove(CartSelectedItem);
                totCalc();
            }
            else
                MessageBox.Show($@"Vælge venligste et element fra kurven");

        }

        //Modify pizza from cart
        /// <summary>Determines whether this instance Canmodify the selected item.</summary>
        /// <returns>
        ///   <c>true</c> if this instance canmodify the specified value; otherwise, <c>false</c>.</returns>
        private bool CanModiFy(object value)
        {
            try
            {
                if (CartSelectedItem is not null)
                {
                    if (CartSelectedItem.Extras is null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void ModifyFromCart(object value)
        {
            if (CartSelectedItem is not null)
            {
                IsButtonClicked = false;

                ModifyWindow modifyWindow = new(CartSelectedItem);
                modifyWindow.ShowDialog();
                totCalc();
            }
            else
                MessageBox.Show($@"Vælge venligste et element fra kurven");

        }


        //GoTo Confirm
        /// <summary>Goes to confirmation Window.</summary>
        /// <param name="value">The value.</param>
        private void GoToConfirm(object value)
        {
            if (CartList.Count is not 0)
            {
                IsButtonClicked = false;

                ConfirmWindow confirmWindow = new(CartList);
                confirmWindow.ShowDialog();
                totCalc();
            }
            else
                MessageBox.Show("Fyld venligste Kurven op", "Hov");
        }

        /// <summary>Determines whether this instance Can go to Confirm the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if this the cart isnt't empty; otherwise, <c>false</c>.</returns>
        private bool CanGoToConfirm(object value)
        {
            if (CartList.Count < 0)
            {
                return false;
            }
            else
                return true;
        }
        #endregion

        #region Functions
        //Calctulator of total price
        /// <summary>  <para> Total Price calculator.</para>
        ///   <para>Calculates According to the price of items in the cart </para>
        /// </summary>
        public void totCalc()
        {
            if (_cartList.Count > 0 || _cartList is not null)
            {
                var c = _cartList;
                List<int> pricesCombined = new();

                for (int i = 0; i < c.Count; i++)
                    pricesCombined.Add(c[i].Total);

                TotPrice = (pricesCombined.Sum()).ToString();
            }

        }
        #endregion

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}