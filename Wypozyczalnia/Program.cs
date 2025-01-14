using System;
using Wypozyczalnia.Models;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Customer> customers = new List<Customer>();
    static int customerIDc = 1;
    static List<Movie> movies = new List<Movie>();
    static int MovieIDc = 1;
    static List<Rental> rentals = new List<Rental>();
    static int rentalIDc = 1;

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
                    ManageMovies();
                    break;
                case "2":
                    ManageRentals();
                    break;
                case "3":
                    ManageCustomers();
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

    //podmenu do wypozyczan

    static void ManageRentals()
    {
        bool isManagingRentals = true;

        while (isManagingRentals)
        {
            Console.WriteLine("\n--- Manage rentals ---");
            Console.WriteLine("1. Add rntal");
            Console.WriteLine("2. View rentals");
            Console.WriteLine("3. Update rental");
            Console.WriteLine("4. Delete rental");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Choose option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRental();
                    break;
                case "2":
                    ViewRentals();
                    break;
                case "3":
                    UpdateRental();
                    break;
                case "4":
                    DeleteRental();
                    break;
                case "5":
                    isManagingRentals = false; 
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    static void AddRental()
    {
        Console.Write("\nEnter ID ");
        if (!int.TryParse(Console.ReadLine(), out int customerID) || customers.All(c => c.ID != customerID))
        {
            Console.WriteLine("Invalid ID");
            return;
        }
 
        Console.Write("Enter Movie ID  ");
        if (!int.TryParse(Console.ReadLine(), out int movieID) || movies.All(m => m.ID != movieID))
        {
            Console.WriteLine("Invalid ID");
            return;
        }

        var rental = new Rental
        {
            ID = rentalIDc++,
            CustomerID = customerID,
            MovieID= movieID,
            RentalDate = DateTime.Now
        };

        rentals.Add(rental);
        Console.WriteLine("Rental added ");
    }

     static void ViewRentals()
    {
        Console.WriteLine("\n--- List of Rentals ---");
        if (rentals.Count == 0)
        {
            Console.WriteLine("No rentals available");
            return;
        }

        foreach (var rental in rentals)
        {
            Console.WriteLine(rental);
        }
    }


     static void UpdateRental()
    {
        Console.Write("\nEnter ID ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID ");
            return;
        }

        var rental = rentals.Find(r => r.ID == id);
        if (rental == null)
        {
            Console.WriteLine("Rental not found");
            return;
        }

        Console.Write("Enter new date  ");
        string returnDateInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(returnDateInput) && DateTime.TryParse(returnDateInput, out DateTime returnDate))
        {
            rental.ReturnDate = returnDate;
        }

        Console.WriteLine("Rental updated ");
    }

    static void DeleteRental()
    {
        Console.Write("\nEnter ID ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID ");
            return;
        }

        var rental = rentals.Find(r => r.ID == id);
        if (rental == null)
        {
            Console.WriteLine("Rental not found");
            return;
        }

        rentals.Remove(rental);
        Console.WriteLine("Rental deleted ");
    }



    //podmenu 2
    static void ManageCustomers()
    {
        bool isManagingCustomers = true;

        while (isManagingCustomers)
        {
            Console.WriteLine("\n--- Customers Manage ---");
            Console.WriteLine("1. Add customer");
            Console.WriteLine("2. View customers");
            Console.WriteLine("3. Update customers");
            Console.WriteLine("4. Delete customers");
            Console.WriteLine("5. Menu");
            Console.Write("Choose option");

            var choice = Console.ReadLine();

           switch (choice)
            {
                case "1":
                    AddCustomer();
                    break;
                case "2":
                    ViewCustomers();
                    break;
                case "3":
                    UpdateCustomer();
                    break;
                case "4":
                    DeleteCustomer();
                    break;
                case "5":
                    isManagingCustomers = false;
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }


        }
    }

    static void AddCustomer()
    {
        Console.Write("\nEnter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter emaail: ");
        string email = Console.ReadLine();

        var newCustomer = new Customer
        {
            ID= customerIDc++,
            Name = name,
            Email = email
        };

        customers.Add(newCustomer);
        Console.WriteLine("Customer added");
    }

     static void ViewCustomers()
    {
        Console.WriteLine("\n--- List of cstomers ---");
        if (customers.Count == 0)
        {
            Console.WriteLine("No customers available");
            return;
        }

        foreach (var customer in customers)
        {
            Console.WriteLine(customer);
        }
    }

    static void UpdateCustomer()
    {
        Console.Write("\nEnter ID  ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID: ");
            return;
        }

        var customer = customers.Find(c => c.ID== id);
        if (customer == null)
        {
            Console.WriteLine("Customer not found");
            return;
        }

        Console.Write("Enter new name ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            customer.Name = newName;
        }

        Console.Write("Enter new email  ");
        string newEmail = Console.ReadLine();
        if (!string.IsNullOrEmpty(newEmail))
        {
            customer.Email = newEmail;
        }

        Console.WriteLine("Customer updated");
    }

    static void DeleteCustomer()
    {
        Console.Write("\nEnter ID");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID");
            return;
        }

        var customer = customers.Find(c => c.ID== id);
        if (customer == null)
        {
            Console.WriteLine("Customer not found");
            return;
        }

        customers.Remove(customer);
        Console.WriteLine("Customer deleted");
    }



    // podmenu 1
    static void ManageMovies()
    {
        while (true)
        {
            Console.WriteLine("\n--- Manage Movies ---");
            Console.WriteLine("1. Add movie");
            Console.WriteLine("2. View movies");
            Console.WriteLine("3. Update movie");
            Console.WriteLine("4. Delete movie");
            Console.WriteLine("5. Main Menu");
            Console.Write("Choose option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MovieADD();
                    break;
                case "2":
                    ViewMovies();
                    break;
                case "3":
                    UpdateMovie();
                    break;
                case "4":
                    DeleteMovie();
                    break;
                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
    static void MovieADD()
    {
        Console.WriteLine("\nMovie title: ");
        string title = Console.ReadLine();

        Console.Write("Movie genre: ");
        string genre = Console.ReadLine();

        var NewMovie = new Movie
        {
            ID = MovieIDc++,
            Title = title,
            Genre = genre,
            Available = true
        };

        movies.Add(NewMovie);
        Console.WriteLine("Movie added");

    }
    //wyswietl (dozr)
    static void ViewMovies()
    {
        Console.WriteLine("\n--- Movie List ---");
        if (movies.Count == 0)
        {
            Console.WriteLine("No movies available");
            return;
        }

        foreach(var movie in movies)
        {
            Console.WriteLine(movie);
        }
    }
    //dodawanie
    static void UpdateMovie()
    {
        Console.WriteLine("\nEnter ID: ");
        if (!int.TryParse(Console.ReadLine(), out int ID))
        {
            Console.WriteLine("Invalid ID");
            return; 
        }

        var movie = movies.Find(m => m.ID == ID);
        if (movie == null)
        {
            Console.WriteLine("Movie not found");
            return;
        
        }

        Console.WriteLine("Enter new title: ");
        string newTitle = Console.ReadLine();
        if (!string.IsNullOrEmpty(newTitle))
        {
            movie.Title = newTitle;

        }

        Console.Write("Enter new genre: ");
        string newGenre = Console.ReadLine();
        if(!string.IsNullOrEmpty(newGenre))
        {
            movie.Genre = newGenre;
        }

        Console.WriteLine("Movie updated");

    }

    //usun
    static void DeleteMovie()
    {

        Console.WriteLine("\nEnter ID: ");
        if (!int.TryParse(Console.ReadLine(), out int ID))
        {
            Console.WriteLine("Invalid ID ");
            return; 
        }

        var movie = movies.Find(m => m.ID == ID);
        if (movie == null)
        {
            Console.WriteLine("Movie not found");
            return;
        }

        movies.Remove(movie);
        Console.WriteLine("Movie deleted ");
        
    }




}