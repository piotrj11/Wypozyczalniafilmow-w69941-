using System;

namespace Wypozyczalnia.Models
{
    public class Rental
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int CustomerID { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate {get; set; } 
        public override string ToString()
        {
            return $"Rental ID: {ID}, Movie ID: {MovieID}, Customer ID: {CustomerID}, Date: {RentalDate.ToShortDateString()}, Return Date: {(ReturnDate.HasValue ? ReturnDate.Value.ToShortDateString() : "Not returned")}";
        }
    }
}
