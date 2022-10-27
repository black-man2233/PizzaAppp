using PizzaApp_WPF.Class;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{
    public class CartModel : Model.PizzaListModel
    {
        //all prices in one place
        private static ObservableCollection<int>? pricesCombined = new();

        //cart items
        private static ObservableCollection<PizzaType>? cartList = new();
        public static ObservableCollection<PizzaType>? CartList
        {
            get { return cartList; }
            set { cartList = value; }
        }







    }
}
