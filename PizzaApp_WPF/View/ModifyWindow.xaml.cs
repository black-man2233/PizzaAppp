using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace PizzaApp_WPF.View
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
#pragma warning disable
            ModifyViewModel mvm;
        public ModifyWindow(PizzaModel pizza)
        {
            InitializeComponent();

            mvm = new ModifyViewModel(pizza);
            this.DataContext = mvm;
        }

        //public static int EditModifiedPrice()
        //{
        //    var extras = mvm.pizza.Extras;

        //    ObservableCollection<int> allPrices = new();

        //    for (int i = 0; i < extras.Count; i++)
        //    {
        //        if (extras[i].Amount > 0)
        //        {
        //            allPrices.Add((extras[i].Amount) * (extras[i].Price));
        //        }
        //    }
        //    return allPrices.Sum();
        //}
        private void ConfirmButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (b.Tag is ExtrasModel exx)
                {
                    exx.Amount++;
                }

            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox c)
            {
                if (c.Tag is ToppingsModel t)
                {
                    t._Selected();

                    //t.Selected = true;
                }
            }

        }
    }
}
