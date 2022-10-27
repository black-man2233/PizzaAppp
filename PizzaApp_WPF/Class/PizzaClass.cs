using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PizzaApp_WPF.Class
{

    public class PizzaType : INotifyPropertyChanged
    {

        //propertien til Pizzaes ID
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");

            }
        }

        //propertien til pizza navnet
        private string? _name;
        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        //propertien til pizzas pris
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

        private string? _description;

        public string? Description
        {
            get { return _description; }
            private set { _description = value; }
        }


        public ObservableCollection<Toppings>? Toppings
        {
            get;
            set;
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
