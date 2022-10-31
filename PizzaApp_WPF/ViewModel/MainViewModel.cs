using PizzaApp_WPF.Class;
using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class MainViewModel
    {
        public static CartModel cartModel = new();
        public static MenuModel menuModel = new MenuModel();

        //DataGrid properties
        public ObservableCollection<PizzaType> menuData
        {
            get { return menuModel.MenuList; }
            set { menuModel.MenuList = value; }
        }
        public ObservableCollection<PizzaType> cartData
        {
            get { return cartModel.CartList; }
            set { cartModel.CartList = value; }
        }

        //Menu Selected Item
        public static int MenuSelectedIndex { get; set; }  //selectedindex from menu.datagrid

        //Cart Selected item 
        public static int CartSelectedIndex { get; set; }  //selectedindex from Cart



    }
}
