using System.ComponentModel;

namespace PizzaApp_WPF.Class
{
    public class DrinksType : INotifyPropertyChanged
    {
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