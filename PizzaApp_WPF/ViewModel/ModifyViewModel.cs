using CommunityToolkit.Mvvm.Input;
using PizzaApp_WPF.Class;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using static PizzaApp_WPF.ViewModel.MainViewModel;

namespace PizzaApp_WPF.ViewModel
{
#pragma warning disable
	public class ModifyViewModel : INotifyPropertyChanged
	{
		public string PizzaDescription
		{
			get { return _cartList[_cartSelectedIndex].Description; }
			set {; }
		}

		public ObservableCollection<Toppings> Toppings
		{
			get
			{
				return MainViewModel.EditThisPizza;
			}
			set
			{
				MainViewModel.EditThisPizza = value;
				OnPropertyChanged("Toppings");
			}
		}


		private ObservableCollection<Toppings> _chosenTippings;
		public ObservableCollection<Toppings> ChosenToppings
		{
			get
			{
				return _chosenTippings;
			}
			set
			{
				_chosenTippings = value;
				OnPropertyChanged("ChosenToppings");
			}
		}


		public RelayCommand<Window> CloseWindowCommand { get; private set; }

		public ModifyViewModel()
		{
			this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
		}

		private void CloseWindow(Window window)
		{
			if (window != null)
			{
				window.Close();
				//NewTopings(MainViewModel.EditThisPizza, _chosenTippings);
			}
		}


		private static void NewTopings(ObservableCollection<Toppings> oldToppings, ObservableCollection<Toppings> newToppings)
		{
			oldToppings.Clear();
			oldToppings = newToppings;
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
