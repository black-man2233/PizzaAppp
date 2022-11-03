using PizzaApp_WPF.Class;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using static PizzaApp_WPF.ViewModel.MainViewModel;
namespace PizzaApp_WPF.View
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
#pragma warning disable
        public ModifyWindow()
        {
            InitializeComponent();
        }

        public ObservableCollection<Toppings> SelectedToppings
        {
            get => SelectedToppings;
            set
            {
                SelectedToppings = value;
                OnPropertyChanged("SelectedToppings");
            }
        }


        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox? c = sender as CheckBox;

            if (c != null)
            {
                Toppings? t = c.Tag as Toppings;

                if (t != null)
                {
                    _cartList[_cartSelectedIndex].Name = "changed";
                    _cartList[_cartSelectedIndex].Toppings[(t.Id) - 1].Selected = false;
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox? c = sender as CheckBox;

            if (c != null)
            {
                Toppings? t = c.Tag as Toppings;

                if (t != null)
                {
                    _cartList[_cartSelectedIndex].Toppings[(t.Id) - 1].Selected = true;

                }
            }

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
