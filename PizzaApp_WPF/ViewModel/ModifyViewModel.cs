using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Utils;
using DevExpress.Utils.Filtering.Internal;
using PizzaApp_WPF.Model;
using PizzaApp_WPF.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class ModifyViewModel : ObservableObject, INotifyPropertyChanged
    {
        public ModifyViewModel(PizzaModel aPizza)
        {
            this.Pizza = aPizza;

            foreach (var item in aPizza.Toppings)
                _tmpToppings.Add((ToppingsModel)item.Clone());

            foreach (var item in aPizza.Extras)
                _tmpExtras.Add((ExtrasModel)item.Clone());
        }

        #region Properties
        //This Pizza
        private static PizzaModel _pizza;
        public PizzaModel Pizza
        {
            get
            {
                return _pizza;
            }
            set
            {
                _pizza = value;
                OnPropertyChanged("Pizza");
            }
        }

        [ObservableProperty] ObservableCollection<ToppingsModel> _tmpToppings = new();

        [ObservableProperty] ObservableCollection<ExtrasModel> _tmpExtras = new();

        #endregion



        public void newTotalPrice()
        {
            var _extras = this.Pizza.Extras;

            List<int> _amountWithPrices = new();

            for (int i = 0; i < _extras.Count; i++)
                if (_extras[i].Amount > 0)
                    _amountWithPrices.Add((_extras[i].Amount * _extras[i].Price));

            this.Pizza.Total = this.Pizza.Price + _amountWithPrices.Sum();
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

