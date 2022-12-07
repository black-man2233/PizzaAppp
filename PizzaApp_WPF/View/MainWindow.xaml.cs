using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System.Linq;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PizzaApp_WPF.View
{
#pragma warning disable
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MainViewModel vm = new MainViewModel();

        private MainViewModel vm = new();
        public MainViewModel Vm
        {
            get { return vm; }
            set { vm = value; }
        }


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Vm;
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
                if (c.SelectedItem is DrinksSize ds)
                {
                    DrinksModel? dm = c.Tag as DrinksModel;

                    vm.CartList.Add((PizzaModel)new PizzaModel(dm.Id, $"{FirstCharToUpper(ds.Name)} {dm.Name}",
                        ds.Price,
                        ds.Price,
                        dm.Description,
                        null, null).Clone());

                    vm.totCalc();
                }

        }

        static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                MessageBox.Show("Noget Gik Galt");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        private void ComboBox_MouseEnter(object sender, MouseEventArgs e)
        {
            ((ComboBox)sender).Text = "";
        }
    }
}
