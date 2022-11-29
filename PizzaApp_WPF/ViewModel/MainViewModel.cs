using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using PizzaApp_WPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

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
            _menuList = menu.PizzasList;

            _drinksList = menu.DrinksList;

            _extrasList = menu.ExtrasList;
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

        [ObservableProperty] ObservableCollection<PizzaModel>? _menuList = new();
        [ObservableProperty] ObservableCollection<ExtrasModel>? _extrasList = new();
        [ObservableProperty] int _menuSelectedIndex = -1;
        [ObservableProperty] PizzaModel _menuSelectedItem;

        [ObservableProperty] ObservableCollection<DrinksModel> _drinksList = new();
        [ObservableProperty] DrinksModel _drinksName;
        private DrinksSize _selectedDrinksSize;
        public DrinksSize SelectedDrinksSize
        {
            get => _selectedDrinksSize;
            set
            {
                _selectedDrinksSize = value;
                AddDrinks();
                OnPropertyChanged("SelectedDrinksSize");
            }
        }

        [ObservableProperty] public static ObservableCollection<PizzaModel> _cartList = new();
        [ObservableProperty] public static PizzaModel _cartSelectedItem;
        [ObservableProperty] int _cartSelectedIndex = -1;

        public static string _totPrice;
        public string TotPrice
        {
            get => _totPrice;

            set { _totPrice = value; OnPropertyChanged("TotPrice"); }
        }

        private bool _isButtonClicked;
        public bool IsButtonClicked
        {
            get { return _isButtonClicked; }
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

        //Add Pizza to cart
        /// <summary>
        /// Adds the selectedItem from Menu to cart.
        /// </summary>
        private void AddToCart(object value)
        {
            if (MenuSelectedItem is not null)
            {
                IsButtonClicked = false;
                if (MenuSelectedItem.DeepCopy() is PizzaModel pizza)
                {
                    ObservableCollection<ExtrasModel> newExtras = new ObservableCollection<ExtrasModel>();
                    for (int i = 0; i < ExtrasList.Count; i++)
                    {
                        ExtrasList[i].DeepCopy();
                        newExtras.Add(ExtrasList[i]);
                    }
                    pizza.Extras = newExtras;
                    _cartList.Add(pizza);
                }
                totCalc();
            }
            else
                MessageBox.Show($@"Vælge venligste et element fra Pizza Menu ");
        }



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

        //Add Drinks to cart
        /// <summary>
        /// Adds the drinks according to the selected Size.
        /// </summary>
        void AddDrinks()
        {
            if (_drinksList is not null)
            {
                var d = SelectedDrinksSize;
                _cartList.Add(new PizzaModel($"{d.Name.Substring(0)} {DrinksName}/", d.Price, d.Price, null, null, null));
                totCalc();
            }
            else
                MessageBox.Show($@"Vælge venligste et element fra Pizza Menu ");
        }



        //Removes items from cart
        /// <summary>
        /// Removes from cart according to the selected Item.
        /// </summary>
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

        //Modify pizza from cart
        /// <summary> Opens a modification window, for the CartSelectedItem</summary>
        /// <param name="value"></param>
        private void ModifyFromCart(object value)
        {
            if (CartSelectedItem is not null)
            {
                IsButtonClicked = false;

                ModifyWindow modifyWindow = new(CartSelectedItem);
                modifyWindow.ShowDialog();
            }
            else
                MessageBox.Show($@"Vælge venligste et element fra kurven");

        }

        /// <summary>Determines whether this instance Canmodify the selected item.</summary>
        /// <returns>
        ///   <c>true</c> if this instance canmodify the specified value; otherwise, <c>false</c>.</returns>
        private bool CanModiFy(object value)
        {
            if (CartSelectedIndex > -1)
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

        //Calctulator of total price
        /// <summary>  <para> Total Price calculator.</para>
        ///   <para>Calculates According to the price of items in the cart </para>
        /// </summary>
        void totCalc()
        {
            var c = _cartList;
            List<int> pricesCombined = new();

            for (int i = 0; i < c.Count; i++)
            {
                pricesCombined.Add(c[i].Total);
            }
            TotPrice = (pricesCombined.Sum()).ToString();
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