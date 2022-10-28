using PizzaApp_WPF.Class;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PizzaApp_WPF.ViewModel
{
    public class ModifyViewModel
    {
        public static int AmountofCheckBoxes;
        public static string PizzaDeScription;

        public ObservableCollection<Toppings>? Toppings { get; set; }
        public ObservableCollection<Toppings>? SelectedToppins { get; set; }


        public ModifyViewModel()
        {
            BackCommand = new DelegateCommand(backAction);
        }

        //Buttons
        public ICommand BackCommand { get; set; }
        void backAction()
        {
            Toppings.Clear();
            SelectedToppins.Clear();
        }








    }
}
