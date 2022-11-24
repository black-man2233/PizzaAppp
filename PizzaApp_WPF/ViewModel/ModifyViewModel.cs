using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class ModifyViewModel : ObservableObject
    {
        public ModifyViewModel(PizzaModel aPizza)
        {
            this.pizza = aPizza;
        }

        [ObservableProperty] PizzaModel pizza;

        //public void Increase_btClick(object sender, RoutedEventArgs e)
        //{
        //    Button b = sender as Button;

        //    ExtrasModel extra = b.Tag as ExtrasModel;

        //    if (extra.Amount < 30)
        //    {
        //        extra.Amount++;

        //        this.pizza.Total = (ModifyWindow.EditModifiedPrice()) + (this.pizza.Price);

        //    }
        //    else
        //    {
        //        MessageBox.Show("Du kan ikke få mere end 30");

        //    }
        //}


    }
}

