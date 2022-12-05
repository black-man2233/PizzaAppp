using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public partial class ToppingsModel : ICloneable, INotifyPropertyChanged
    {
        #region Properties
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

        private bool _selected;
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
        #endregion


        public ToppingsModel(int id, string name, bool selected)
        {
            this.Id= id;
            this._name = name;
            this._selected = selected;
        }

        public Object Clone()
        {
            ToppingsModel toppings = new(this.Id, this.Name, this._selected);

            return toppings;
        }


        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}