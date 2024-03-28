using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static classandencapluation.Program;

namespace classandencapluation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library(10);

        Book book1 = new Book(1, "Book 1", 20.5m, 3, "elmi fantastika");
        Book book2 = new Book(2, "Book 2", 15.75m, 5, "roman");

        library.AddBook(book1);
        library.AddBook(book2);

        Console.WriteLine("Butun kitablar:");
        library.ShowAllBooks();

        Console.WriteLine("\njanr uzre filtirlenmis kitab 'elmi fantastika':");
        Book[] filteredByGenre = library.GetFilteredBooks("elmi fantastika");
        foreach (Book book in filteredByGenre)
        {
            book.ShowInfo();
        }

        Console.WriteLine("\nmebleg uzre filtirlenmis kitab (10, 20):");
        Book[] filteredByPrice = library.GetFilteredBooks(10m, 20m);
        foreach (Book book in filteredByPrice)
        {
            book.ShowInfo();
        }
    }

        }
    public class Product
    {

        private decimal _price;
         public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }
        public int No { get; set; }
        public string Name { get; set; }
        public Product(int no, string name, decimal price, int count)
        {
            No = no;
            Name = name;
            _price = price;
            _count = count;
        }


    }
    

    public class Book : Product
    {
        public string Genre { get; set; }

        public Book(int no, string name, decimal price, int count, string genre) : base(no, name, price, count)
        {
            Genre = genre;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine( $"Count: {Count}");
            Console.WriteLine($"No: {No}");
        }
    }
    public class Library
    {
        public Book[] Books;

        public Library(int capacity)
        {
            Books = new Book[capacity];
        }

        public void AddBook(Book book)
        {
            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i] == null)
                {
                    Books[i] = book;
                    return;
                }
            }
            Console.WriteLine("kitabxana doludur.kitab elave etmek mumkun deyil");
        }

        public Book[] GetFilteredBooks(string genre)
        {
            Book[] filteredBooks = Array.FindAll(Books, b => b != null && b.Genre == genre);
            return filteredBooks;
        }

        public Book[] GetFilteredBooks(decimal minPrice, decimal maxPrice)
        {
            Book[] filteredBooks = Array.FindAll(Books, b => b != null && b.Price >= minPrice && b.Price <= maxPrice);
            return filteredBooks;
        }

        public void ShowAllBooks()
        {
            foreach (Book book in Books)
            {
                if (book != null)
                    book.ShowInfo();
            }
      }
        }
    }
    
