using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp_WPF.Model.Toppings
{
    public class ToppingsListModel : INotifyPropertyChanged
    {
		private ObservableCollection<ToppingsModel> _toppings;
		public ObservableCollection<ToppingsModel> Toppings
		{
			get
			{
				return _toppings;
			}
			set
			{
                _toppings = value;
				OnPropertyChanged("MyProperty");
			}
		}


        


		#region OnPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
