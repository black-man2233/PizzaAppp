using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public partial class DrinksModel : ObservableObject, INotifyPropertyChanged, ICloneable
    {
        #region Propperties
        //Image
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
       
        //name
        private string? _name;
        public string? Name
        {
            get => _name;
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
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged("Price");
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

        //capacity or size
        private ObservableCollection<DrinksSize> _capacity;
        public ObservableCollection<DrinksSize> Capacity
        {
            get => _capacity;
            set
            {
                _capacity = value;
                OnPropertyChanged("Capacity");
            }
        }
        #endregion

        public DrinksModel(string url,  string name, int price, string desc, ObservableCollection<DrinksSize> s)
        {
            ImageUrl = url;
            Name = name;
            Price = price;
            Description = desc;
            _capacity = s;
        }
        
        
        public object Clone()
        {
            return new DrinksModel(this._imageUrl, this.Name, this.Price, this.Description,this.Capacity);
        }

        #region OnPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        #endregion

    }
}