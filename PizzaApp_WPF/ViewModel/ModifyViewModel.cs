using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Utils;
using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class ModifyViewModel : ObservableObject
    {
        public ModifyViewModel(PizzaModel aPizza)
        {
            this.Pizza = aPizza;
            this.Toppings= aPizza.Toppings;
            this.Extras= aPizza.Extras;

            #region Commands initialised

            IncreaseAmmountCommand = new Command.RelayCommand.RelayCommand(IncreaseAmmount, CanIncrease);
            //DecreaseAmountCommand = new Command.RelayCommand.RelayCommand(RemoveFromCart, CanRemove);
            //ClearAllAmountCommand = new Command.RelayCommand.RelayCommand(AddToCart, CanAdd);

            #endregion

        }

        [ObservableProperty] ObservableCollection<ToppingsModel> _toppings = new();
        [ObservableProperty] ObservableCollection<ExtrasModel> _extras = new();
        [ObservableProperty] string _description;
        [ObservableProperty] PizzaModel _pizza;
        [ObservableProperty] int _total;
        [ObservableProperty] bool _isSelected = true;



        #region ICommands  
        public ICommand IncreaseAmmountCommand { get; set; }
        public ICommand DecreaseAmountCommand{ get; set; }
        public ICommand ClearAllAmountCommand { get; set; }
        #endregion



        #region Event Method
        private bool CanIncrease(object value)
        {
            //if ( < -1 || > 30)
            //    return false;
            //else
                return true;
        }
        void IncreaseAmmount(object value)
        {
            //if (_drinksList is not null)
            //{
            //    var d = SelectedDrinksSize;
            //    _cartList.Add(new PizzaModel($"{d.Name.Substring(0)} {DrinksName}/", d.Price, d.Price, null, null, null));
            //    totCalc();
            //}
            //else
            //    MessageBox.Show($@"Vælge venligste et element fra Pizza Menu ");
        }




        #endregion




    }
}

