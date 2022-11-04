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
        public MainViewModel()
        {

            AddToCartCommand = new DelegateCommand(Add);
            //EditCommand = new DelegateCommand(Edit);
            DeleteCommand = new DelegateCommand(Delete);
        }

        //DataGrid properties
        PizzaListModel PizzaListModel = new PizzaListModel();
        private static ObservableCollection<PizzaType> _menuList = PizzaListModel.ItemsList;
        public static ObservableCollection<PizzaType> MenuList
        {
            get { return _menuList; }
            set { _menuList = value; }
        }

        private static int _menuSelectedIndex;
        public int MenuSelectedIndex
        {
            get
            {
                return _menuSelectedIndex;
            }
            set
            {
                _menuSelectedIndex = value;
                OnPropertyChanged("MenuSelectedIndex");
            }
        }



        public static ObservableCollection<PizzaType>? _cartList = new();
        public ObservableCollection<PizzaType>? CartList
        {
            get { return _cartList; }
            set { _cartList = value; OnPropertyChanged("CartList"); }
        }
        public static int _cartSelectedIndex = 0;
        public int CartSelectedIndex
        {
            get => _cartSelectedIndex;
            set
            {
                _cartSelectedIndex = value;
                OnPropertyChanged("CartSelectedIndex");
            }
        }  //selectedindex from Cart

        private ObservableCollection<Toppings> toppings = _menuList[_menuSelectedIndex].Toppings;
        public ObservableCollection<Toppings> Toppings
        {
            get => toppings;
            set
            {
                toppings = value;
                OnPropertyChanged("Toppings");
            }
        }




        //Buttons prop

        public static ICommand AddToCartCommand { get; set; } //Add Button Command
        public void Add()
        {
            PizzaType selectedPizzaInfo = _menuList[MenuSelectedIndex];

            ObservableCollection<Toppings> toppsAsList = _menuList[MenuSelectedIndex].Toppings;

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
