using System.Windows;
using static PizzaAppp.MainWindow;

namespace PizzaAppp
{
    /// <summary>
    /// Interaction logic for ModifyPizzaWindow.xaml
    /// </summary>
    public partial class ModifyPizzaWindow : Window
    {
        static int selectedIndex = IndexOfSelctedInCart;

        //string a = (MainWindow.cartData[selectedIndex].Description).ToString();
        public ModifyPizzaWindow()
        {
            InitializeComponent();
            PDesc_Tb.Text = string.Empty;

            PDesc_Tb.Text = cartData[0].Description;

        }


        ///back Button to the Main Window
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

    }
}
