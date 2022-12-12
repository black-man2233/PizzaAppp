using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PizzaApp_WPF.Model
{
#pragma warning disable

    public partial class PizzaModel : ObservableObject, INotifyPropertyChanged, ICloneable
    {
        #region Properties
        //Image Url
        private string _imageUrl;
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                _imageUrl = value;
                OnPropertyChanged("ImageUrl");
            }
        }

        //id
        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        //name
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

        //price
        private int _price;
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

        //total
        private int _total;
        public int Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }

        //description
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        //Toppings
        private ObservableCollection<ToppingsModel> _toppings;
        public ObservableCollection<ToppingsModel> Toppings
        {
            get
            {
                return _toppings;
            }
            set
            {
                _toppings = value;
                OnPropertyChanged("Toppings");
            }
        }

        //Extras
        private ObservableCollection<ExtrasModel> _extras = new();
        public ObservableCollection<ExtrasModel> Extras
        {
            get { return _extras; }
            set { _extras = value; OnPropertyChanged("Extras"); }
        }
        #endregion

        #region Constructors
        public PizzaModel(string url, int id, string? name, int price, int total, string? description, ObservableCollection<ToppingsModel>? toppings, ObservableCollection<ExtrasModel>? extras)
        {
            this.ImageUrl= url;
            this.ID= id;
            Name = new(name);
            Price = price;
            Total = total;
            Description = description;
            Toppings = toppings != null ? (new(toppings)) : null;
            Extras = extras != null ? (new(extras)) : null;
        }

        #endregion

        #region Clone
        public object Clone()
        {
            return new PizzaModel(this.ImageUrl, this.ID, this.Name, this.Price, this.Total, this.Description, this.Toppings, this.Extras);
        }
        #endregion


        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
