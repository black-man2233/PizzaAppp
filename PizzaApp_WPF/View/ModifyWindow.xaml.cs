using DevExpress.Utils.MVVM;
using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

#pragma warning disable
namespace PizzaApp_WPF.View
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
        static ModifyViewModel mvm;
        public ModifyWindow(PizzaModel pizza)
        {
            InitializeComponent();
            mvm = new ModifyViewModel(pizza);
            this.DataContext = mvm;
        }

        #region checkbox
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox c)
            {
                if (c.Tag is ToppingsModel t)
                {

                }
            }

        }
        #endregion



        #region Increase and decrease
        private void IncreaseButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
                if (b.Tag is ExtrasModel exx)
                    if (exx.Amount is not >= 30)
                    {
                        exx.Amount++;
                        mvm.newTotalPrice();
                    }
        }

        private void DecreaseButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
                if (b.Tag is ExtrasModel exx)
                    if (exx.Amount is not <= 0)
                    {
                        exx.Amount--;
                        mvm.newTotalPrice();
                    }
        }
        #endregion



        #region Confirm And Cancel
        private void ConfirmButton(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void CancelButton(object sender, RoutedEventArgs e)
        {
            mvm.Pizza.Extras.Clear();
            mvm.Pizza.Toppings.Clear();
            
            foreach (var item in mvm.TmpExtras)
            {
                mvm.Pizza.Extras.Add((ExtrasModel)item.Clone());
            }

            foreach (var item in mvm.TmpToppings)
            {
                mvm.Pizza.Toppings.Add((ToppingsModel)item.Clone());
            }

            this.Close();
        }
        #endregion
    }
}
