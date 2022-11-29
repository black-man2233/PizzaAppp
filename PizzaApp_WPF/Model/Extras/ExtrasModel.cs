using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{
    public partial class ExtrasModel : ObservableObject
    {
        #region Properties
        [ObservableProperty] string? _name;
        [ObservableProperty] int _price;
        [ObservableProperty] int _amount;
        #endregion

        #region Constructor
        public ExtrasModel(string? name, int price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        public ExtrasModel DeepCopy()
        {
            ExtrasModel extra = new(this.Name, this.Price, this.Amount);
            return extra;
        }

        public ObservableCollection<ExtrasModel> DeepCopyList(ObservableCollection<ExtrasModel> ext)
        {
            ObservableCollection<ExtrasModel> newExtras = new ObservableCollection<ExtrasModel>();
            for (int i = 0; i < ext.Count; i++)
            {
                ext[i].DeepCopy();
                newExtras.Add(ext[i]);
            }

            return newExtras;

        }
        #endregion



    }
}