using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static System.Drawing.Image;

namespace PizzaApp_WPF.View
{
    /// <summary>
    /// Interaction logic for ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {

        public ConfirmWindow(ObservableCollection<PizzaModel> _cartList)
        {
            InitializeComponent();
            ConfirmViewModel vm = new(_cartList);
            DataContext = vm;

        }

        private new void MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button b)
            {
                Image? i = b.Content as Image;
                i.Source = new BitmapImage(new Uri(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaApp_WPF\Image\trashOpen.png"));
            }


        }

        private new void MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button b)
            {
                Image? i = b.Content as Image;
                i.Source = new BitmapImage(new Uri(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaApp_WPF\Image\trashClosed.png"));
            }

        }
    }
}
