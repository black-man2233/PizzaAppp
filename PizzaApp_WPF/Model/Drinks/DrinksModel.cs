using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaApp_WPF.Model
{
    public partial class DrinksModel : ObservableObject, INotifyPropertyChanged
    {
        #region Propperties
        //name
        private string _name;
        public string Name
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}