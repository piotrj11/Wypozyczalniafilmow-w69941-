namespace Wypozyczalnia.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}";
        }
    }
}