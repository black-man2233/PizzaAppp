using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class ModifyViewModel : ObservableObject, INotifyPropertyChanged
    {
        public ModifyViewModel(PizzaModel __pizza)
        {
            pizza = __pizza;
            _pizzaDescription= pizza.Description;
            _toppings= pizza.Toppings;
            _extras= pizza.Extras;
            this._total = pizza.Total.ToString();
        }


        [ObservableProperty] public static PizzaModel pizza;

        [ObservableProperty] string? _pizzaDescription;

        [ObservableProperty] static ObservableCollection<ToppingsModel>? _toppings;

        [ObservableProperty] public static ObservableCollection<ExtrasModel>? _extras;


        private string _total;
        public string Total
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





        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }));
        }

    }
}

