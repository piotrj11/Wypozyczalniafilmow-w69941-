using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Movie Rent ---");
            Console.WriteLine("1. Movie manage");
            Console.WriteLine("2. Rentals manage");
            Console.WriteLine("3. Customers manage");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Movie manage selected");
                    break;
                case "2":
                    Console.WriteLine("Rental manage selected");
                    break;
                case "3":
                    Console.WriteLine("Customers manage selected");
                    break;
                case "4":
                    Console.WriteLine("Exiting");
                    return;

                default:
                    Console.WriteLine("Invalid option");
                    break;

            

            }
        }
    }
}