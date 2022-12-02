using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaApp_WPF.Model
{
    public partial class ExtrasModel : ObservableObject, INotifyPropertyChanged, ICloneable
    {
        #region Properties
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

        //Price
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

        //Amount
        private int _amount;
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }
        #endregion

        #region Constructor
        public ExtrasModel(string? name, int price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }
        #endregion

        #region Clone
        public object Clone()
        {
            return new ExtrasModel(Name, Price, Amount);
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