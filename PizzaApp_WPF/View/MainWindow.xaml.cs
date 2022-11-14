using Microsoft.Xaml.Behaviors;
using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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
                DrinksModel d = vm.Drinks[vm.DrinksSelected];

                vm.CartList.Add(new PizzaModel(d.Name, d.Price, d.Price, d.Name, d.Capacity, null));

                vm.totCalc();
            }
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                MainViewModel? vm = b.Tag as MainViewModel;
                try
                {
                    vm.SelectedPizza = vm.CartList[vm.CartSelectedIndex];
                    ModifyWindow modifyWindow = new(vm.SelectedPizza);
                    modifyWindow.Show();

                    vm.totCalc();

                }
                catch (Exception)
                {
                    _ = MessageBox.Show("Dette Element kan ikke modificeres", "Hov");
                }
            }
            else if (sender is DataGrid d)
            {
                try
                {

                    var vm = d.Tag as MainViewModel;

                    vm.SelectedPizza = vm.CartList[vm.CartSelectedIndex];
                    ModifyWindow modifyWindow = new(vm.SelectedPizza);
                    modifyWindow.Show();

                    vm.totCalc();
                }
                catch (Exception)
                {

                    _ = MessageBox.Show("Dette Element kan ikke modificeres", "Hov");

                }

            }

            else
            {
                _ = MessageBox.Show("Ingen Valgte Pizza fra Kurven", "Hov");
            }
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
                    _vm.totCalc();

                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($@"Vælge venligste et element fra Pizza Menu \n {ex.Message}");
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
                    _vm.totCalc();

                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($@"Vælge venligste et element fra kurven  {ex.Message}");
                }

            }
        }
    }
}
