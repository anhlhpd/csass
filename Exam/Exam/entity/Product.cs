namespace Exam.entity
{
    public class Product
    {
        private string _id;
        private string _name;
        private decimal _price;

        public Product()
        {
        }

        public Product(string id, string name, decimal price)
        {
            this._id = id;
            this._name = name;
            this._price = price;
        }

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public decimal Price
        {
            get => _price;
            set => _price = value;
        }
    }
}