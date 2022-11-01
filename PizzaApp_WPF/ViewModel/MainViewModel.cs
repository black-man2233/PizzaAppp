using PizzaApp_WPF.Class;
using PizzaApp_WPF.Model;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public class MainViewModel
    {
        //DataGrid properties
        PizzaListModel PizzaListModel = new PizzaListModel();
        private static ObservableCollection<PizzaType> _menuList = PizzaListModel.ItemsList;
        public static ObservableCollection<PizzaType> MenuList
        {
            get { return _menuList; }
            set { _menuList = value; }
        }
        public static int MenuSelectedIndex { get; set; }  //selectedindex from menu.datagrid


        //cart items
        public static ObservableCollection<PizzaType>? _cartList = new();
        public ObservableCollection<PizzaType>? CartList
        {
            get { return _cartList; }
            set { _cartList = value; OnPropertyChanged("CartList"); }
        }
        public static int _cartSelectedIndex;
        public int CartSelectedIndex
        {
            get => _cartSelectedIndex;
            set
            {
                _cartSelectedIndex = value;
                OnPropertyChanged("CartSelectedIndex");
            }
        }  //selectedindex from Cart

        public ObservableCollection<Toppings> Toppings
        {
            get { return _menuList[MenuSelectedIndex].Toppings; }
            set { OnPropertyChanged("Drinks"); }
        }

        public MainViewModel()
        {
            AddToCartCommand = new DelegateCommand(Add);
            EditCommand = new DelegateCommand(Edit);
            DeleteCommand = new DelegateCommand(Delete);
        }

        //Buttons prop


        public ICommand EditCommand { get; set; } //Edit Button 
        private static ObservableCollection<Toppings?> _editThisPizza;
        public static ObservableCollection<Toppings> EditThisPizza
        {
            get
            {
                return _editThisPizza;
            }
            set
            {
                _editThisPizza = value;
            }
        }

        private void Edit()
        {
            try
            {
                EditThisPizza = _cartList[CartSelectedIndex].Toppings;
                View.ModifyWindow modify = new();
                modify.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Ingen Valgte Pizza fra Kurven", "How");
            }

        } //Edit Action



        public static ICommand AddToCartCommand { get; set; } //Add Button Command
        public void Add()
        {
            _cartList.Add(_menuList[MenuSelectedIndex]);

        } //Add button Action


        public ICommand DeleteCommand { get; set; } //Delete Button Command
        private void Delete()
        {

            try
            {
                if (CartList.Count > 0)
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
