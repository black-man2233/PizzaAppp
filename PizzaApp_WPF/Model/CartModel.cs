using PizzaApp_WPF.Class;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PizzaApp_WPF.Model
{
    public class CartModel
    {
        //cart items
        private static ObservableCollection<PizzaType>? cartList = new();

        public ObservableCollection<PizzaType>? CartList
        {
            get { return cartList; }
            set { OnPropertyChanged("CartList"); }
        }

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
