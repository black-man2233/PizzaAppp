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
        static PizzaListModelModel menu = new();
        public MainViewModel()
        {
            AddToCartCommand = new DelegateCommand(Add);
            //EditCommand = new DelegateCommand(Edit);
            DeleteCommand = new DelegateCommand(Delete);
        }



        [ObservableProperty] static ObservableCollection<PizzaType>? _menuList = menu.PizzasList;
        [ObservableProperty] private static int _menuSelectedIndex;

        [ObservableProperty] static ObservableCollection<PizzaType>? _cartList = new();
        [ObservableProperty] static int _cartSelectedIndex = 0;



        [ObservableProperty] private static ObservableCollection<DrinksModel> _drinks = menu.DrinksList;
        [ObservableProperty] private ObservableCollection<DrinkSizeModel> _drinkSize;


        //Buttons prop
        public static ICommand AddToCartCommand { get; set; } //Add Button Command
        public void Add()
        {
            PizzaType selectedPizzaInfo = _menuList[MenuSelectedIndex];

            ObservableCollection<ToppingsModel> toppsAsList = new(selectedPizzaInfo.Toppings);

            _cartList.Add(new PizzaType(selectedPizzaInfo.Id, selectedPizzaInfo.Name, selectedPizzaInfo.Price, selectedPizzaInfo.Description, toppsAsList));

        } //Add button Action



        ////public ICommand EditCommand { get; set; } //Edit Button 
        ////private void Edit()
        ////{
        ////    try
        ////    {
        ////        ModifyWindow modifyWindow = new ModifyWindow();
        ////        modifyWindow.ShowDialog();
        ////    }
        ////    catch (Exception)
        ////    {
        ////        MessageBox.Show("Ingen Valgte Pizza fra Kurven", "How");
        ////    }

        ////} //Edit Action


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