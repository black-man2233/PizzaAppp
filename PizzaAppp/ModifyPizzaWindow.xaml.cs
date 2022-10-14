using System.Windows;

namespace PizzaAppp
{
    /// <summary>
    /// Interaction logic for ModifyPizzaWindow.xaml
    /// </summary>
    public partial class ModifyPizzaWindow : Window
    {
        public ModifyPizzaWindow()
        {
            InitializeComponent();


        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
