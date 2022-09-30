using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppp.Classes
{
    public class PizzaerneClass
    {
        public int ID;

        //propertien til pizza navnet
        private string _pizzaName;
        public string PizzaName
        {
            get
            {
                return _pizzaName;
            }

            set
            {
                _pizzaName = value;

            }
        }


        //propertien til pizzaens pris
        private int _pizzaPrice;

        public int PizzaPrice
        {
            get { return _pizzaPrice; }
            set { _pizzaPrice = value; }
        }

        //ertsatter id navne og prissen til pizzaen
        public PizzaerneClass(int id, string pName, int pPrice)
        {
            this.ID = id;
            this.PizzaName = pName;
            this.PizzaPrice = pPrice;

        }
    }
}
