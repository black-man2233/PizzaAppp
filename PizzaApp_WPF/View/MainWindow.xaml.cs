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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is ComboBox c)
            {
                c.Text = "NIbba";
            }

        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid d = sender as DataGrid;

            PizzaModel p = d.SelectedItem as PizzaModel;

            p.printHash();
        }
    }
}
