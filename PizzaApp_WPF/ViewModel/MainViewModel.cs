using PizzaApp_WPF.Class;
using PizzaApp_WPF.Model;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PizzaApp_WPF.ViewModel
{
    public partial class MainViewModel
    {
        CartModel cartModel = new();
        MenuModel menuModel = new MenuModel();

#pragma warning disable
        public MainViewModel()
        {
            AddToCartCommand = new DelegateCommand(Add);
            EditCommand = new DelegateCommand(Edit);
            DeleteCommand = new DelegateCommand(Delete);
        }
#pragma warning restore

        //DataGrid properties
        public ObservableCollection<PizzaType> menuData
        {
            get { return menuModel.MenuList; }
            set { menuModel.MenuList = value; }
        }
        public ObservableCollection<PizzaType>? cartData
        {
            get { return cartModel.CartList; }
            set { cartModel.CartList = value; }
        }


        //Buttons prop
        public int MenuSelectedIndex { get; set; }  //selectedindex from menu.datagrid
        public ICommand AddToCartCommand { get; set; } //Add Button Command
        private void Add()
        {
#pragma warning disable
            cartModel.CartList.Add(menuData[MenuSelectedIndex]);
            OnPropertyChanged("cartData");
#pragma warning restore

        } //Add button Action


        public static int CartSelectedIndex { get; set; }  //selectedindex from Cart
        public ICommand DeleteCommand { get; set; } //Delete Button Command
        private void Delete()
        {
#pragma warning disable
            if (cartModel.CartList.Count > 0)
            {
                cartModel.CartList.Remove(cartModel.CartList[CartSelectedIndex]);
                OnPropertyChanged("cartData");
            }
            else
            {
                MessageBox.Show("Ikke flere Pizza til rådighed");
            }
#pragma warning restore

        } //Delete Action



        public ICommand EditCommand { get; set; } //Edit Button 
        private void Edit()
        {
#pragma warning disable
            cartModel.CartList.Add(menuData[CartSelectedIndex]);
            OnPropertyChanged("cartData");
#pragma warning restore

        } //Edit Action





        //it updates data, so the datagrid gets the latest update
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }



    }
}
