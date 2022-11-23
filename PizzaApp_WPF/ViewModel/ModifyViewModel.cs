using CommunityToolkit.Mvvm.ComponentModel;
using PizzaApp_WPF.Model;
using System.Windows.Controls;
using System.Windows;
using PizzaApp_WPF.View;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
    public partial class ModifyViewModel : ObservableObject
    {
        public ModifyViewModel(PizzaModel aPizza)
        {
            this.pizza = aPizza;
        }

        [ObservableProperty] public PizzaModel pizza = null;

        #region Button
        public void Increase_btClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            ExtrasModel extra = b.Tag as ExtrasModel;

            if (extra.Amount < 30)
            {
                extra.Amount++;

                this.pizza.Total = (ModifyWindow.EditModifiedPrice()) + (this.pizza.Price);

            }
            else
            {
                MessageBox.Show("Du kan ikke få mere end 30");

            }
        }

        #endregion

    }
}

