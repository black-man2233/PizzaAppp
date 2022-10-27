using PizzaApp_WPF.Class;
using PizzaApp_WPF.Model;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PizzaApp_WPF.ViewModel
{
    public partial class MainViewModel
    {
        //Pizza Menu
        public static ObservableCollection<PizzaType> menuData { get; set; } = PizzaListModel.itemsList;

        //Cart List
        public static ObservableCollection<PizzaType>? cartData { get; set; } = CartModel.CartList;

        //Selected item from the menu cart
        public static int SelectedIndex { get; set; }


        public ICommand AddToCartCommand { get; set; }


        private void Add()
        {
            cartData.Add(ViewModel.MainViewModel.menuData[ViewModel.MainViewModel.SelectedIndex]);

        }

        public MainViewModel()
        {
            AddToCartCommand = new DelegateCommand(Add);

        }

    }
}
