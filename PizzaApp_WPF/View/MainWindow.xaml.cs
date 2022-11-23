using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Internal;
using DevExpress.Utils.MVVM;
using PizzaApp_WPF.Model;
using PizzaApp_WPF.ViewModel;
using System;
using System.Collections.ObjectModel;
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
        MainViewModel mvm = new();


        public MainWindow()
        {
            InitializeComponent();
        }

        private static bool IsDrink(PizzaModel element)
        {
            return element.Extras == null;
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (b.Tag is MainViewModel vm)
                {
                    try
                    {
                        var pizzafinale = vm.MenuList[vm.MenuSelectedIndex];
                        ObservableCollection<ExtrasModel> extras = new();

#pragma warning disable CS8604 // Possible null reference argument.
                        //vm.CartList.Add(new PizzaModel(
                        //    new(pizzafinale.Name),
                        //    pizzafinale.Price,
                        //    pizzafinale.Total,
                        //    pizzafinale.Description,
                        //    new(collection: pizzafinale.Toppings),
                        //    new(extras)));
#pragma warning restore CS8604 // Possible null reference argument.

                        vm.TotPrice = MainViewModel.totCalc();
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show($@"Vælge venligste et element fra Pizza Menu \n {ex.Message}");
                    }
                }
            }
        }
        private void AddToCart(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid d)
            {
                if (d.SelectedItem is PizzaModel p)
                {
                    if (d.Tag is MainViewModel vm)
                    {
                        try
                        {
                            PizzaModel pizzafinale = vm.MenuSelectedValue;
                            ObservableCollection<ExtrasModel> extras = new();
                            //vm.CartList.Add(new PizzaModel(new(pizzafinale.Name),
                            //                               pizzafinale.Price,
                            //                               pizzafinale.Total,
                            //                               pizzafinale.Description,
                            //                               new(collection: pizzafinale.Toppings),
                            //                               new(extras)));

                            vm.TotPrice = MainViewModel.totCalc();
                        }
                        catch (Exception ex)
                        {

                            _ = MessageBox.Show($@"Vælge venligste et element fra Pizza Menu \n {ex.Message}");


                        }

                    }
                }
            }
        }

        private static void Redigere(MainViewModel vm)
        {
            try
            {
                vm.SelectedPizza = vm.CartList[vm.CartSelectedIndex];

                if (IsDrink(vm.SelectedPizza) == false)
                {
                    if (vm.SelectedPizza.Extras.Count <= 0)
                    {
                        foreach (var item in vm.Extras)
                        {
                            vm.SelectedPizza.Extras.Add(item);
                        }
                    }
                    ModifyWindow modifyWindow = new(vm.SelectedPizza);
                    _ = modifyWindow.ShowDialog();

                }
                else
                {
                    _ = MessageBox.Show("Dette Element kan ikke modificeres", "Hov");
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"{ex.Message}");
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
                    _vm.TotPrice = MainViewModel.totCalc().ToString();

                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($@"Vælge venligste et element fra kurven  {ex.Message}");
                }

            }
        }

        private void DrinksDoubleclick(object sender, MouseButtonEventArgs e)
        {
            ListBox? a = sender as ListBox;

            if (a.Tag is MainViewModel vm)
            {
                if (a.SelectedItem is DrinksModel d)
                {
                    //MainViewModel._cartList.Add(new PizzaModel(d.Name, d.Price, d.Price, d.Name, null, null));
                }

                vm.TotPrice = MainViewModel.totCalc();
            }
        }
        private void DrinkSizeSelected(object sender, RoutedEventArgs e)
        {
            if (sender is ComboBox c)
            {
                if (c.Tag is MainViewModel vm)
                {
                    if (c.SelectedItem is DrinksSize d)
                    {
                        //vm.CartList.Add(new PizzaModel(d.Name, d.Price, d.Price, d.Name, null, null));
                    }

                    vm.TotPrice = MainViewModel.totCalc();
                }
            }
        }

        private void ToPayment_bt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button? b = sender as Button;
                MainViewModel? vm = b.Tag as MainViewModel;


                ConfirmWindow confirm = new(_cartList: vm.CartList);
                _ = confirm.ShowDialog();

                vm.TotPrice = MainViewModel.totCalc().ToString();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
