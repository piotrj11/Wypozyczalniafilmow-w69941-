using System.Reflection;

namespace Wypozyczalnia.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public bool Available { get; set; } = true; 
        public string Title { get; set; }
        public string Genre { get; set; }
        public override string ToString()
        {
            return $"ID: {ID}, Title: {Title}, Genre: {Genre}, Available: {Available}";

        }
    }
}
