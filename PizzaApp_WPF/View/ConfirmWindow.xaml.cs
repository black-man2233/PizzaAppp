using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Drawing.Image;

namespace PizzaApp_WPF.View
{
    /// <summary>
    /// Interaction logic for ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
#pragma warning disable
        // Prep stuff needed to remove close button on window
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public ConfirmWindow(ObservableCollection<PizzaModel> _cartList)
        {
            InitializeComponent();
            ConfirmViewModel vm = new(_cartList);
            DataContext = vm;

            Loaded += ToolWindow_Loaded;

        }

        void ToolWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Code to remove close box from window
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
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

        private void DeletePizza(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                PizzaModel? element = b.Tag as PizzaModel;


                _ = ConfirmViewModel._pizzas.Remove(element);
                _ = MainViewModel._cartList.Remove(element);


            }

        }

        private void DeleteDrinks(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                PizzaModel element = b.Tag as PizzaModel;
                
                ConfirmViewModel._drinks.Remove(element);
                MainViewModel._cartList.Remove(element);


            }
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
