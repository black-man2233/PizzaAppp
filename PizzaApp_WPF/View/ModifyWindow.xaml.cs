using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System.Windows;
namespace PizzaApp_WPF.View
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
#pragma warning disable
        public ModifyWindow(PizzaModel pizza)
        {
            InitializeComponent();
            ModifyViewModel mvm = new ModifyViewModel(pizza);
            this.DataContext = mvm;
        }

        //checkBoxes
        //private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    if (sender is CheckBox c)
        //    {
        //        if (c.Tag is ToppingsModel)
        //        {
        //            //MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected = false;
        //            //MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Name = "False";
        //            //MessageBox.Show($"{MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected}");

        //        }
        //    }
        //}

        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox? c = sender as CheckBox;

        //    if (c != null)
        //    {
        //        ToppingsModel? t = c.Tag as ToppingsModel;

        //        if (t != null)
        //        {
        //            //MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected = true;
        //            //MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Name = "true";
        //            //MessageBox.Show($"{MainViewModel._cartList[MainViewModel._cartSelectedIndex].Toppings[(t.Id) - 1].Selected}");

        //        }
        //    }

        //}




        ////Buttons

        //private void Decrease_btClick(object sender, RoutedEventArgs e)
        //{
        //    Button b = sender as Button;

        //    ExtrasModel extra = b.Tag as ExtrasModel;
        //    if (extra.Amount > 0)
        //    {
        //        extra.Amount--;
        //        mvm.pizza.Total = (EditModifiedPrice()) + (mvm.pizza.Price);

        //    }
        //    else
        //    {
        //        MessageBox.Show("Du kan ikke få mindre end nul");
        //    }

        //}

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
    }
}
