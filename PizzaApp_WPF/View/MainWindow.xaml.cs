using PizzaApp_WPF.Model;
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



        public ICommand SelectedDrinksSizeChangedCommand
        {
            get { return (ICommand)GetValue(SelectedDrinksSizeChangedCommandProperty); }
            set { SetValue(SelectedDrinksSizeChangedCommandProperty, value); }
        }
        public static readonly DependencyProperty SelectedDrinksSizeChangedCommandProperty =
            DependencyProperty.Register("MyProperty", typeof(ICommand), typeof(DrinksModel), new PropertyMetadata(null));



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedDrinksSizeChangedCommand != null)
            {
                //SelectedDrinksSizeChangedCommand.Execute(Yaoo.SelectedItem);
            }
        }
    }
}
