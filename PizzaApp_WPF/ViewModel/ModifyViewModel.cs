using PizzaApp_WPF.Class;
using System.Collections.ObjectModel;
using System.ComponentModel;
using static PizzaApp_WPF.ViewModel.MainViewModel;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public class ModifyViewModel : INotifyPropertyChanged
    {
        public string PizzaDescription
        {
            get
            {
                return _cartList[_cartSelectedIndex].Description;
            }
            set
            {
                _cartList[_cartSelectedIndex].Description = value;
                OnPropertyChanged("PizzaDescription");
            }

        } //Pizza Desription
        public ObservableCollection<Toppings> Toppings
        {
            get
            {
                return _cartList[_cartSelectedIndex].Toppings;
            }
            set
            {
                _cartList[_cartSelectedIndex].Toppings = value;
                OnPropertyChanged("Toppings");
            }
        }



        public ModifyViewModel()
        {
            //Toppings = _cartList[_cartSelectedIndex].Toppings;
        } // The constructor



        //it updates data, so the datagrid gets the latest update
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }



        //#region INotifyPropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName] string name = "")
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //        handler(this, new PropertyChangedEventArgs(name));
        //}
        //#endregion
    }
}
