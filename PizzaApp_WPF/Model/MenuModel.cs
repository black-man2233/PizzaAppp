using PizzaApp_WPF.Class;
using System.Collections.ObjectModel;

namespace PizzaApp_WPF.Model
{
	public class MenuModel
	{
		PizzaListModel PizzaListModel = new PizzaListModel();

		private ObservableCollection<PizzaType> _menuList = PizzaListModel.ItemsList;

		public ObservableCollection<PizzaType> MenuList
		{
			get { return _menuList; }
			set { _menuList = value; }
		}





	}
}
