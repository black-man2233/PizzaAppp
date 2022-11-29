using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public partial class ToppingsModel : ObservableObject
    {
        [ObservableProperty] string _name;
        [ObservableProperty] bool _selected;

        public ToppingsModel(string name, bool selected)
        {
            this._name = name;
            this._selected = selected;
        }

        public ToppingsModel DeepCopy()
        {
            ToppingsModel toppings = new(this.Name, this._selected);

            return toppings;
        }


        public ObservableCollection<ToppingsModel> DeepCopyToList(ObservableCollection<ToppingsModel> a)
        {
            ObservableCollection<ToppingsModel> t = a;

            foreach (var item in t)
            {
                t.Add(item.DeepCopy());
            }

            return t;
        }


        public bool _Selected()
        {
            return this.Selected = true;
        }
        public bool _UnSelected()
        {
            return this.Selected = false;
        }


    }
}