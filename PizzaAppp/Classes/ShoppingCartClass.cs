using System.ComponentModel;

namespace PizzaAppp.Classes

{
    /// <summary>
    /// Shoping Cart Class
    /// </summary>
    public class ShoppingCart : INotifyPropertyChanged
    {
        //propertin til navnet
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        //propertin til prisen
        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }

        }

        //propertin til Pris i alt
        private int _totalPrice;

        private int TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }



        public ShoppingCart(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }


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
