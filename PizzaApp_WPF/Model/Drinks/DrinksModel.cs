using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public partial class DrinksModel : ObservableObject, INotifyPropertyChanged
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
       
        //ID
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

        #region OnPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}