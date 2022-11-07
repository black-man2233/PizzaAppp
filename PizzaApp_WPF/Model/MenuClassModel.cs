using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{
    public class MenuType
    {
        public ObservableCollection<PizzaType>? Pizzas { get; set; }
        public ObservableCollection<DrinksModel>? Drinks { get; set; }


    }
}
