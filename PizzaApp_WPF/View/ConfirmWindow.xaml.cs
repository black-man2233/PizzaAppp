using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System;
using System.Collections.ObjectModel;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PizzaApp_WPF.View
{
//#pragma warning disable
// Prep stuff needed to remove close button on window
    /// <summary>
    /// Interaction logic for ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        #region Remove TopClose Button
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        internal void ToolWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Code to remove close box from window
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            _ = SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
        #endregion

        ConfirmViewModel vm;
        #region Constructor
        public ConfirmWindow(ObservableCollection<PizzaModel> _cartList)
        {
            InitializeComponent();
            vm = new(_cartList);
            DataContext = vm;

            Loaded += ToolWindow_Loaded;
        }
        #endregion

        private new void MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button b)
            {
                Image? i = b.Content as Image;
                i.Height = 42;
                i.Width = 42;
                //i.Source = new BitmapImage(new Uri(@"https://img.icons8.com/external-kiranshastry-solid-kiranshastry/512/external-recycle-bin-graph-design-kiranshastry-solid-kiranshastry.png"));
            }
        }
        private new void MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button b)
            {
                Image? i = b.Content as Image;
                i.Height = 40;
                i.Width = 40;
                //i.Source = new BitmapImage(new Uri(@"https://img.icons8.com/external-tal-revivo-color-tal-revivo/512/external-trash-can-layout-for-a-indication-to-throw-trash-mall-color-tal-revivo.png"));
            }

        }
    }
}
