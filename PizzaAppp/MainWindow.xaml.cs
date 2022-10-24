using PizzaAppp.Classes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using static PizzaAppp.Classes.MenuJsonToList;

namespace PizzaAppp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Menu_Dg.ItemsSource = MenuJsonToList.MenuData;
            Cart_Dg.Items.Clear();
            Cart_Dg.ItemsSource = cartData;

        }

        //cart list
        public static ObservableCollection<PizzasMenu> cartData = new ObservableCollection<PizzasMenu>();

        //used to send get the index of the selected index from the cart
        public static int IndexOfSelctedInCart;

        ///<summary>
        /// Total Price Calculator
        ///listen med alle priser
        ///static List<int> allPrices = new List<int>();
        ///static int _totPrice = allPrices.Sum();
        ///public string totPrice
        ///{
        ///    get { return $"Total {_totPrice}"; }
        ///    set { _totPrice = int.Parse(value); OnPropertyChanged("totPrice"); OnPropertyChanged/("_totPrice"); }
        ///}
        ///</summary>


        // Opens up the pizza customise window according to the selected pizzas toppings
        private void CustomiseThisPizzaWindow()
        {
            IndexOfSelctedInCart = Convert.ToInt32(Cart_Dg.SelectedIndex);
            ModifyPizzaWindow modifypizzawindow = new ModifyPizzaWindow();
            modifypizzawindow.ShowDialog();

            MessageBox.Show(cartData[0].Description.ToString());


        }

        // Opens up The customazation window for the current pizza
        public void Cart_Dg_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => CustomiseThisPizzaWindow();

        //edit button
        private void Edit_btn_Click(object sender, RoutedEventArgs e) => CustomiseThisPizzaWindow();

        //delete button 
        private void Delete_btn_Click(object sender, RoutedEventArgs e) => cartData.Remove(cartData[Cart_Dg.SelectedIndex]);

        //add to the cart btn
        private void Add_btn_Click(object sender, RoutedEventArgs e) => cartData.Add(MenuData[Menu_Dg.SelectedIndex]);

        //updates data
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }

    }
}
