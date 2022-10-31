using PizzaApp_WPF.Class;
using PizzaApp_WPF.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
	public class ModifyViewModel : INotifyPropertyChanged
	{
		//all toppings
		private static ObservableCollection<Toppings> _toppings = PizzaListModel.ItemsList[1].Toppings;
		public ObservableCollection<Toppings> Toppings
		{
			get
			{
				return _toppings;
			}
			set
			{
				_toppings = value;
				OnPropertyChanged("Toppings");
			}
		}


		//it updates data, so the datagrid gets the latest update
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string PropertyNavn)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
			}
		}


	}
}
