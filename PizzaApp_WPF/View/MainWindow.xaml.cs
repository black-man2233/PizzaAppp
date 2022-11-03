using System.Windows;

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

        private void ToPayment_bt_Click(object sender, RoutedEventArgs e)
        {
            ConfirmWindow confirm = new();
            confirm.ShowDialog();
        }
    }
}
