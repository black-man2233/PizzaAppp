using PizzaApp_WPF.Class;
using PizzaApp_WPF.ViewModel;
using Prism.Commands;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using static PizzaApp_WPF.ViewModel.MainViewModel;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public class HomeButtonsModel
    {
        public HomeButtonsModel()
        {
            AddToCartCommand = new DelegateCommand(Add);
            EditCommand = new DelegateCommand(Edit);
            DeleteCommand = new DelegateCommand(Delete);
        }



        //Buttons prop
        public static ICommand AddToCartCommand { get; set; } //Add Button Command
        public void Add()
        {
            cartModel.CartList.Add(MainViewModel.menuModel.MenuList[MenuSelectedIndex]);
            OnPropertyChanged("cartData");

        } //Add button Action


        public ICommand DeleteCommand { get; set; } //Delete Button Command
        private void Delete()
        {

            try
            {
                if (cartModel.CartList.Count > 0)
                {
                    cartModel.CartList.Remove(cartModel.CartList[CartSelectedIndex]);
                    OnPropertyChanged("cartData");
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

#pragma warning restore

        } //Delete Action



        public static View.ModifyWindow modify = new();
        public ICommand EditCommand { get; set; } //Edit Button 

        public static PizzaType? editThisPizza = new();
        private void Edit()
        {


            try
            {
                editThisPizza = cartModel.CartList[CartSelectedIndex];
                modify.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Ingen Valgte Pizza fra Kurven", "How");
            }

        } //Edit Action


        //it updates data, so the datagrid gets the latest update
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }

    }
}
