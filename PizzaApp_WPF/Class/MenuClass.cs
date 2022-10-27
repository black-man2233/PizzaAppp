using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Class
{
    public class MenuClass
    {
        //drinks
        private ObservableCollection<DrinksType> _drinks;
        public ObservableCollection<DrinksType> Drinks
        {
            get { return _drinks; }
            set { _drinks = value; }
        }

        //Pizza Menu
        private ObservableCollection<PizzaType> _pizza;

        public ObservableCollection<PizzaType> Pizza
        {
            get { return _pizza; }
            set { _pizza = value; }
        }



    }
}
