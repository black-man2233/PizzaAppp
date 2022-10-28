using Newtonsoft.Json;
using PizzaApp_WPF.Class;
using System.Collections.ObjectModel;
using System.IO;

namespace PizzaApp_WPF.Model
{
    public class PizzaListModel
    {
        //stigen til Pizza.Json
        private static readonly string jsonText = File.ReadAllText(@"C:\Users\Kevin\Source\Repos\PizzaAppp\PizzaApp_WPF\Database\Items.json");

        // konverter JSON string til liste med Pizza 
        private static ObservableCollection<PizzaType> itemsList = JsonConvert.DeserializeObject<ObservableCollection<PizzaType>>(jsonText);
        public static ObservableCollection<PizzaType> ItemsList { get => itemsList; set => itemsList = value; }


    }
}
