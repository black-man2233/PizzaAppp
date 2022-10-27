namespace PizzaApp_WPF.Class
{
    public class Toppings
    {
        //prorpertie for id
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        //propertie for the name
        private string? _name;

        public string? Name
        {
            get { return _name; }
            set { _name = value; }
        }


        //propertie for the price
        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

    }
}