using PizzaApp_WPF.Class;
using PizzaApp_WPF.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PizzaApp_WPF.View
{
    /// <summary>
    /// Interaction logic for ModifyWindow.xaml
    /// </summary>
    public partial class ModifyWindow : Window
    {
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


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;

            if (c != null)
            {
                Toppings t = c.Tag as Toppings;

                if (t != null)
                {
                    ModifyViewModel.SelectedToppings.Add(t);
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
