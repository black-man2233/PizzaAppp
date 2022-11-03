using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PizzaApp_WPF.Class
{

    public class PizzaType : INotifyPropertyChanged
    {

        public int Id
        {
            get { return Id; }
            set
            {
                Id = value;
                OnPropertyChanged("Id");

            }
        }

        public string? Name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Price
        {
            get { return Price; }
            set
            {
                Price = value;
                OnPropertyChanged("Price");
            }
        }

        public string? Description
        {
            get { return Description; }
            set { Description = value; }
        }

        public ObservableCollection<Toppings>? Toppings
        {
            get;
            set;
        }

        public PizzaType(int id, string? name, int price, string? description, ObservableCollection<Toppings>? toppings)
        {
#pragma warning disable
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Toppings = new ObservableCollection<Toppings>(toppings);
        }
#pragma warning restore



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
