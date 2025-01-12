using System;
using Wypozyczalnia.Models;
using System.Collections.Generic;

class Program
{
    static List<Movie> movies = new List<Movie>();
    static int MovieIDc = 1;


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
    // podmenu
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