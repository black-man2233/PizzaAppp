using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Utils;
using DevExpress.Utils.Url;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace PizzaApp_WPF.Model
{

    public partial class PizzaModel : ObservableObject
    {
#pragma warning disable
        #region Properties
        [ObservableProperty] ObservableCollection<ToppingsModel>? _toppings;
        [ObservableProperty] ObservableCollection<ExtrasModel>? _extras;
        [ObservableProperty] string? _description;
        [ObservableProperty] string? _name;
        [ObservableProperty] int _total;
        [ObservableProperty] int _price;
        private PizzaModel pizzaModel;

        #endregion


        #region Constructors
        public PizzaModel(string? name, int price, int total, string? description, ObservableCollection<ToppingsModel>? toppings, ObservableCollection<ExtrasModel>? extras)
        {
            Name = new(name);
            Price = price;
            Total = total;
            Description = Description != null ? (new(description)) : null;
            Toppings = toppings != null ? (new(toppings)) : null;
            Extras = extras != null ? (new(extras)) : null;
        }
        #endregion
        public PizzaModel DeepCopy()
        {
            PizzaModel pizzaModel = new(this.Name, this.Price, this.Total, this.Description, this.Toppings, this.Extras);
            return pizzaModel;
        }


        #region Hash Code for all properties
        public void printHash()
        {
            MessageBox.Show($@" HashCode for thisItemProperty
Item = {this.GetHashCode()} 
Toppings = {this.Toppings.GetHashCode()}
Extras = {this.Extras.GetHashCode()}
");
        }
        #endregion
    }
}
