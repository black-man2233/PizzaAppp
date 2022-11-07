using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
                //_cartList[_cartSelectedIndex].Description = value;
                OnPropertyChanged("PizzaDescription");
            }

        }

        private ObservableCollection<ToppingsModel> _toppings;
        public ObservableCollection<ToppingsModel> Toppings
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
