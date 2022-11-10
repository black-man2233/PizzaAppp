using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class MainViewModel : ObservableObject
    {
        static PizzaListModel menu = new();
        public MainViewModel()
        {
            AddToCartCommand = new DelegateCommand(Add);
            DeleteCommand = new DelegateCommand(Delete);

            //_cartList.Add(_menuList[1]);
            //_cartList.Add(_menuList[3]);
            //_cartList.Add(_menuList[4]);

        }


        [ObservableProperty] static ObservableCollection<PizzaModel>? _menuList = menu.PizzasList;
        [ObservableProperty] private static int _menuSelectedIndex = -1;

        [ObservableProperty] public static ObservableCollection<PizzaModel>? _cartList = new();
        [ObservableProperty] public static int _cartSelectedIndex = -1;


        [ObservableProperty] public static ObservableCollection<DrinksModel> _drinks = menu.DrinksList;
        [ObservableProperty] private ObservableCollection<ToppingsModel> _drinkSize;
        [ObservableProperty] public static int _drinksSelected;


        [ObservableProperty] public static PizzaModel _selectedPizza;



        //Buttons prop
        public static ICommand AddToCartCommand
        { get; set; } //Add Button Command
        public void Add()
        {
            try
            {
                PizzaModel selectedPizzaInfo = _menuList[MenuSelectedIndex];
                ObservableCollection<ToppingsModel> toppsAsList = new(selectedPizzaInfo.Toppings);
                _cartList.Add(selectedPizzaInfo);

            }
            catch (Exception e)
            {
                MessageBox.Show($@"Vælge venligste et element fra Pizza Menu \n {e.Message}");
            }

        } //Add button Action


        public ICommand DeleteCommand { get; set; } //Delete Button Command
        private void Delete()
        {

            try
            {
                if (_cartList.Count > 0)
                {
                    _cartList.Remove(_cartList[CartSelectedIndex]);
                    CartSelectedIndex -= CartSelectedIndex;

                }
                else
                {
                    MessageBox.Show($"Ikke Flere Pizzaer Tilbage", "Hov");

                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"Der gik noget galt \n {e.Message}", "Hov");

            }


        } //Delete Action

    }
}