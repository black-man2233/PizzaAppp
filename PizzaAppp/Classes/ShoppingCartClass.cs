///<summary>
///This Class was supossed to be a class for the shopping cart
/// </summary>

//using System.Collections.ObjectModel;
//using System.ComponentModel;

//namespace PizzaAppp.Classes

//{
//    /// <summary>
//    /// Shoping Cart Class
//    /// </summary>
//    public class ShoppingCart : PizzasMenu
//    {
//        //propertie for the id
//        private int _id;
//        public int Id
//        {
//            get { return _id; }
//            set { _id = value; }
//        }

//        //propertin til navnet
//        private string _name;
//        public string Name
//        {
//            get { return _name; }
//            set
//            {
//                _name = value;
//                OnPropertyChanged("Name");
//            }
//        }

//        //propertin til prisen
//        private int _price;
//        public int Price
//        {
//            get { return _price; }
//            set
//            {
//                _price = value;
//                OnPropertyChanged("Price");
//            }

//        }

//        public ObservableCollection<Toppings> Toppings { get; set; }





//        //public ShoppingCart(int id, string name, int price, ObservableCollection<Toppings> toppings)
//        //{
//        //    this.Id = id;
//        //    this.Name = name;
//        //    this.Price = price;
//        //    this.Toppings = toppings;
//        //}


//        //it updates data, so the datagrid gets the latest update
//        public event PropertyChangedEventHandler PropertyChanged;
//        private void OnPropertyChanged(string PropertyNavn)
//        {
//            if (PropertyChanged != null)
//            {
//                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
//            }
//        }

//        ////propertin til Pris i alt
//        //private int _totalPrice;

//        //private int TotalPrice
//        //{
//        //    get { return _totalPrice; }
//        //    set
//        //    {
//        //        _totalPrice = value;
//        //        OnPropertyChanged("TotalPrice");
//        //    }
//        //}


//    }

//}
