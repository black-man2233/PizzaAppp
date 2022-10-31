using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using static PizzaApp_WPF.ViewModel.MainViewModel;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public class TotalPriceCalculator
    {
        private static ObservableCollection<int> allPrices = new();

        public static void totCalc()
        {
            allPrices.Clear();
            for (int i = 0; i < cartModel.CartList.Count; i++)
            {
                allPrices.Add(cartModel.CartList[i].Price);
            }
        }
        public int TotalPrice { get => allPrices.Sum(); set { TotalPrice = value; OnPropertyChanged("TotalPrice"); } }
        public string TotalPriceString { get => $"Total {TotalPrice} kr."; set { TotalPriceString = value.ToString(); OnPropertyChanged("TotalPriceString"); } }


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
