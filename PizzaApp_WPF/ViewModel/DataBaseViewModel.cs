using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using PizzaApp_WPF.Model.Toppings;
using System;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using DevExpress.Internal;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    public partial class DataBaseViewModel : ObservableObject

    {
        public DataBaseViewModel()
        {
            ConnectToDataBase();

            _pizzasList = new();
            for (int i = 0; i < _dbPizzas.Count; i++)
                _pizzasList.Add((PizzaModel)_dbPizzas[i].Clone());

            _drinksList = new();
            for (int i = 0; i < _dbDrinks.Count; i++)
                _drinksList.Add((DrinksModel)_dbDrinks[i].Clone());

            _extrasList = new ObservableCollection<ExtrasModel>(JsonConvert.DeserializeObject<ObservableCollection<ExtrasModel>>(ExtrasDbText));
            _toppingsList = new ObservableCollection<ToppingsListModel>(JsonConvert.DeserializeObject<ObservableCollection<ToppingsListModel>>(ToppingsText));

        }

        #region Properties
        [ObservableProperty] ObservableCollection<PizzaModel>? _pizzasList;

        [ObservableProperty] ObservableCollection<DrinksModel>? _drinksList;


        ////Extras
        private readonly string ExtrasDbText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaApp_WPF\Database\ExtrasDb.json");

        [ObservableProperty] ObservableCollection<ExtrasModel>? _extrasList;

        ////Toppings
        private readonly string ToppingsText = File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppp\PizzaApp_WPF\Database\ToppingsDB.json");

        [ObservableProperty] ObservableCollection<ToppingsListModel>? _toppingsList;
        #endregion


        #region DataBaseData
        private ObservableCollection<PizzaModel> _dbPizzas = new();
        private ObservableCollection<DrinksModel> _dbDrinks = new();
        void ConnectToDataBase()
        {
            PizzaListCon();

            DrinksDbCon();
        }


        void DrinksDbCon()
        {
            const string connstring = @"Data Source = .\SQLEXPRESS; Initial Catalog=PizzaApp; Integrated Security = true; Encrypt = False ";

            SqlConnection connection = new SqlConnection(connstring);
            connection.Open();

            string query = "Select * From Drinks";
            SqlCommand command = new(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string output = "\n";

                //creates a local list of the drinks Size and fills it up
                ObservableCollection<DrinksSize> _dbsizes = new();
                _dbsizes.Add(new DrinksSize(
                    (string)reader.GetValue(4), 
                    (int)reader.GetValue(5),
                    (bool)bool.Parse(reader.GetValue(6).ToString())
                    ));

                _dbsizes.Add(new DrinksSize(
                    (string)reader.GetValue(7),
                    (int)reader.GetValue(8),
                    (bool)bool.Parse(reader.GetValue(9).ToString())
                    ));

                _dbsizes.Add(new DrinksSize(
                    (string)reader.GetValue(10),
                    (int)reader.GetValue(11),
                    (bool)bool.Parse(reader.GetValue(12).ToString())
                    ));

                //Adds the a new drink with the recent list of drinks
                _dbDrinks.Add(new DrinksModel(
                    (string)reader.GetValue(0) /* Image Link */ ,
                    (string)reader.GetValue(1) /* name*/ ,
                    (int)reader.GetValue(2) /* Price */ ,
                    (string)reader.GetValue(3) /* Description*/ ,
                    _dbsizes/* Size*/ )
                    );
            }

            connection.Close();
        }

        void PizzaListCon()
        {
            const string connstring = @"Data Source = .\SQLEXPRESS; Initial Catalog=PizzaApp; Integrated Security = true; Encrypt = False ";

            SqlConnection con = new SqlConnection(connstring);
            con.Open();

            string query = "Select * From PizzasList";
            SqlCommand cmd = new(query, con);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string output = $"Output = {reader.GetValue(0)} - {reader.GetValue(1)} - {reader.GetValue(2)} - {reader.GetValue(3)} - {reader.GetValue(4)}";

                //MessageBox.Show(output);

                this._dbPizzas.Add(new PizzaModel(
                    (string)reader.GetValue(0) /* Description */ ,
                    (int)reader.GetValue(1) /* Id */ ,
                    (string)reader.GetValue(3) /* Name*/ ,
                    (int)reader.GetValue(4) /* Price*/ ,
                    (int)reader.GetValue(4) /* Total = Price*/ ,
                    (string)reader.GetValue(2) /* Description*/ ,
                    null /* Toppings */ ,
                    null /* Extras */ )
                    );
            }

            con.Close();
        }

        #endregion



    }
}

