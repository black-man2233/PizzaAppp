using DevExpress.Utils;
using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PizzaApp_WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }


        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid d = sender as DataGrid;

            PizzaModel p = d.SelectedItem as PizzaModel;

            p.printHash();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox c)
            {
                if (c.SelectedItem is DrinksSize ds)
                {
                    DrinksModel? dm = c.Tag as DrinksModel;

                    vm.CartList.Add((PizzaModel)new PizzaModel($"{ds.Name.Substring(0)} {dm.Name}",
                        ds.Price,
                        ds.Price,
                        dm.Description,
                        null, null).Clone());

                    vm.totCalc();
                }
            }
        }



        private void ComboBox_MouseEnter(object sender, MouseEventArgs e)
        {
            ((ComboBox)sender).Text = "";
        }
    }
}
