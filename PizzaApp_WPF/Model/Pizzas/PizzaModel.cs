using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Utils;
using DevExpress.Utils.Url;
using System;
using System.Collections.Generic;
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
        public PizzaModel(int id, string? name, int price, int total, string? description, ObservableCollection<ToppingsModel>? toppings, ObservableCollection<ExtrasModel>? extras)
        {
            this.ID= id;
            Name = new(name);
            Price = price;
            Total = total;
            Description = Description != null ? (new(description)) : null;
            Toppings = toppings != null ? (new(toppings)) : null;
            Extras = extras != null ? (new(extras)) : null;
        }
        #endregion

        #region Clone
        public object Clone()
        {
            return new PizzaModel(this.ID, this.Name, this.Price, this.Total, this.Description, this.Toppings, this.Extras);
        }
        #endregion

        #region Hash Code for all properties
        public void printHash()
        {
            try
            {
                MessageBox.Show($"This Has = {this.GetHashCode()}  \nToppings Hash = {this.Toppings.GetHashCode()} \nExtras Has ={this.Extras.GetHashCode()}");
            }
            catch (Exception)
            {
                MessageBox.Show("No HashCodes For u BRother");
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
