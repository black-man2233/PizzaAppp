using PizzaAppp.Classes;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using static PizzaAppp.MainWindow;

namespace PizzaAppp
{
    /// <summary>
    /// Interaction logic for ModifyPizzaWindow.xaml
    /// </summary>
    public partial class ModifyPizzaWindow : Window
    {

        //Topins Total Price
        private int _toppingTottal;
        public int ToppingsTotal
        {
            get { return _toppingTottal; }
            set { _toppingTottal = value; }
        }

        //List of all Toppings
        static ObservableCollection<Toppings> Toppings { get; set; } = new ObservableCollection<Toppings>();

        static ObservableCollection<CheckBox> Checkboxes { get; set; } = new ObservableCollection<CheckBox>();
        public ModifyPizzaWindow()
        {
            InitializeComponent();


            int amountOfToppings = cartData[IndexOfSelctedInCart].Toppings.Count;


            //Generates Toppings According to the Selected Pizza from the cart
            //Adds those pizzas to a list of Toppings
            for (int i = 0; i < amountOfToppings; i++)
            {
                //creates amountOfToppings new checkbox
                CheckBox _ToppingBox = new CheckBox();

                _ToppingBox.Name = $"{cartData[IndexOfSelctedInCart].Toppings[i].Name}";

                _ToppingBox.Content = $"{_ToppingBox.Name}";
                Checkboxes.Add(_ToppingBox);

                Toppings.Add(new Toppings((_ToppingBox.Name), (cartData[IndexOfSelctedInCart].Toppings[i].Price)));



            }

            Toppings_Lb.Items.Clear();
            Toppings_Lb.ItemsSource = Checkboxes;

            for (int i = 0; i < Toppings.Count; i++)
            {
                _toppingTottal += Toppings[i].Price;
            }

            TotalPris_Tb.Text = $"Total: {_toppingTottal} kr.";

        }

        ///back Button to the Main Window
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();


            Toppings.Clear();
            Checkboxes.Clear();

        }



    }


}
