using System.ComponentModel;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public class ToppingsModel : INotifyPropertyChanged
    {
        public ToppingsModel(int Id, string Name, int Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
        }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }


        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }



        private int _price;
        /// <summary>Gets or sets the price.</summary>
        /// <value>The price.</value>
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }




        private bool _selected;
        /// <summary>Gets or sets a value indicating whether this <see cref="ToppingsModel" /> is selected.</summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }





        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyNavn));
        }
    }
}