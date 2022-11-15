using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
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

        private void ToPayment_bt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button? b = sender as Button;
                MainViewModel? vm = b.Tag as MainViewModel;


                ConfirmWindow confirm = new(_cartList: vm.CartList);
                _ = confirm.ShowDialog();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DrinksDoubleclick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListBox? a = sender as ListBox;

            if (a.Tag is MainViewModel vm)
            {
                //DrinksModel d = vm.Drinks[vm.DrinksSelected];
                //vm.CartList.Add(new PizzaModel(d.Name, d.Price, d.Price, d.Name, null, null));

                if (a.SelectedItem is DrinksModel d)
                {

                    MainViewModel._cartList.Add(new PizzaModel(d.Name, d.Price, d.Price, d.Name, null, null));


                }

                MainViewModel._totPrice = MainViewModel.totCalc();
            }
        }
        private void DrinkSizeSelected(object sender, RoutedEventArgs e)
        {
            ComboBox? c = sender as ComboBox;

            if (c.Tag is DrinksModel d)
            {
                if (c.SelectedValue is DrinksSize p)
                {
                    MainViewModel._cartList.Add(new PizzaModel(d.Name, p.Price, p.Price, d.Name, null, null));
                }

            }
        }


        void Redigere(MainViewModel vm)
        {
            try
            {
                vm.SelectedPizza = vm.CartList[vm.CartSelectedIndex];

                if (IsDrink(vm.SelectedPizza) == false)
                {
                    ModifyWindow modifyWindow = new(vm.SelectedPizza);
                    modifyWindow.Show();
                    MainViewModel._totPrice = MainViewModel.totCalc();

                }
                else
                {
                    _ = MessageBox.Show("Dette Element kan ikke modificeres", "Hov");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}");
            }
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                MainViewModel? vm = b.Tag as MainViewModel;
                Redigere(vm);
            }
            else if (sender is DataGrid d)
            {
                MainViewModel? vm = d.Tag as MainViewModel;
                Redigere(vm);

            }
            else
            {
                _ = MessageBox.Show("Ingen Valgte Pizza fra Kurven", "Hov");
            }
        }

        private static bool IsDrink(PizzaModel element)
        {
            return element.Extras == null;
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                MainViewModel? _vm = b.Tag as MainViewModel;

                ObservableCollection<PizzaModel>? _cartList = _vm.CartList;

                try
                {
                    PizzaModel p = _vm.MenuList[_vm.MenuSelectedIndex];
                    _cartList.Add(new PizzaModel(p.Name, p.Price, p.Total, p.Description, p.Toppings, p.Extras));
                    MainViewModel._totPrice = MainViewModel.totCalc();

                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($@"Vælge venligste et element fra Pizza Menu \n {ex.Message}");
                }
            }
        }
        private void AddToCart(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid d)
            {
                try
                {
                    MainViewModel vm = d.Tag as MainViewModel;

                    PizzaModel currentPizza = d.CurrentItem as PizzaModel;
                    if (currentPizza != null)
                    {
                        vm.CartList.Add(new PizzaModel(currentPizza.Name, currentPizza.Price, currentPizza.Price, currentPizza.Description, currentPizza.Toppings, currentPizza.Extras));
                        MainViewModel._totPrice = MainViewModel.totCalc();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Someting Went Wrong, ", "How");
                }


            }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                MainViewModel? _vm = b.DataContext as MainViewModel;
                ObservableCollection<PizzaModel>? _cartList = _vm.CartList;
                try
                {
                    _ = _vm.MenuList[_vm.CartSelectedIndex];
                    _ = _cartList.Remove(_cartList[_vm.CartSelectedIndex]);
                    MainViewModel._totPrice = MainViewModel.totCalc();

                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($@"Vælge venligste et element fra kurven  {ex.Message}");
                }

            }
        }

       
    

        private void Combooo_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox c = sender as ComboBox;

            c.Text = "Hello";
        }
    }
}
