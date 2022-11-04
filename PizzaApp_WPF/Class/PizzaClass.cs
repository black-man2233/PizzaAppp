using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PizzaApp_WPF.Class
{

    public class PizzaType : INotifyPropertyChanged
    {

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value; OnPropertyChanged("Name");
            }
        }


        private int _price;
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }


        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public ObservableCollection<Toppings>? Toppings
        {
            get;
            set;
        }


#pragma warning disable
        /// <summary>Initializes a new instance of the <see cref="PizzaType" /> class.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="price">The price.</param>
        /// <param name="description">The description.</param>
        /// <param name="toppings">The toppings.</param>
        public PizzaType(int id, string? name, int price, string? description, ObservableCollection<Toppings>? toppings)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Toppings = new ObservableCollection<Toppings>(toppings);
        }
#pragma warning restore



        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>Called when [property changed].</summary>
        /// <param name="PropertyNavn">The property navn.</param>
        private void OnPropertyChanged(string PropertyNavn)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyNavn));
        }

    }

}
