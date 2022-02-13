using System;
using System.Collections.Generic;

namespace Laboratory_work_4
{
    class Library
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Librarian { get; set; }
        public int NumberOfBooks { get; set; }
        public int NumberOfHalls { get; set; }
        public int NumberOfSeatsInTheHall { get; set; }
        public float VisitorsPerDay { get; set; }
        public static int QuantityLibraries = 0;
        public List<Book> Books = new List<Book>();
    public Library()
        {
            Name = "Is unknown";
            Street = "Is unknown";
            Librarian = "Is unknown";
            NumberOfBooks = 300;
            NumberOfHalls = 0;
            NumberOfSeatsInTheHall = 0;
            VisitorsPerDay = 0f;
            QuantityLibraries++;
        }
        public Library(string name, string street, string librarian, int books, int halls, int seats, float visitors)
        {
            Name = name;
            Street = street;
            Librarian = librarian;
            NumberOfBooks = books;
            NumberOfHalls = halls;
            NumberOfSeatsInTheHall = seats;
            VisitorsPerDay = visitors;
            QuantityLibraries++;
        }

        public override string ToString()
        {
            return $"Library name: {Name}\n" +
                   $"Street: {Street}\n" +
                   $"Last name of the librarian: {Librarian}\n" +
                   $"Number of books in the library: {NumberOfBooks}\n" +
                   $"Number of halls in the library: {NumberOfHalls}\n" +
                   $"Number of seats in the hall: {NumberOfSeatsInTheHall}\n" +
                   $"Average number of visitors per day: {VisitorsPerDay}\n\n";
        }
        public void ShowName()
        {
            Console.WriteLine("Library name: " + Name);
        }
    }
}