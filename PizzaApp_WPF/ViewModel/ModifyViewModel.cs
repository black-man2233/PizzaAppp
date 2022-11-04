using PizzaApp_WPF.Class;
using System.Collections.ObjectModel;
using System.ComponentModel;
using static PizzaApp_WPF.ViewModel.MainViewModel;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public class ModifyViewModel : INotifyPropertyChanged
    {
        private string _pizzaDescr;
        public string PizzaDescription
        {
            get => _pizzaDescr;
            set
            {
                _cartList[_cartSelectedIndex].Description = value;
                OnPropertyChanged("PizzaDescription");
            }

        }

        private ObservableCollection<Toppings> _toppings;
        public ObservableCollection<Toppings> Toppings
        {
            get => this._toppings;
            set
            {
                _toppings = value;
                OnPropertyChanged("Toppings");
            }
        }




        //it updates data, so the datagrid gets the latest update
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }

    }
}
