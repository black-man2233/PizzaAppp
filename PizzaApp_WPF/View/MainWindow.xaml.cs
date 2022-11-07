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
            _ = confirm.ShowDialog();
        }


        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            //if (MainViewModel._cartList.Count > 0)
            //{
            //    if (sender is Button)
            //    {
            //        if (MainViewModel._cartList[MainViewModel._cartSelectedIndex] is not null)
            //        {
            //            ModifyWindow modifyWindow = new(MainViewModel._cartList[MainViewModel._cartSelectedIndex]);
            //            _ = modifyWindow.ShowDialog();

            //        }
            //    }
            //}
            //else
            //{
            //    _ = MessageBox.Show("Ingen Valgte Pizza fra Kurven", "How");

            //}
        }
    }
}
