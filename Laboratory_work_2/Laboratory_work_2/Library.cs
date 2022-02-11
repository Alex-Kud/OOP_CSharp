using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_work_2
{
    class Library
    {
        public string Name;
        public string Street;
        public string Librarian;
        public int NumberOfBooks;
        public int NumberOfHalls;
        public int NumberOfSeatsInTheHall;
        public float VisitorsPerDay;
        public static int QuantityLibraries = 0;
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

        public void SetName(string name)
        {
            Name = name;
        }
        public void SetStreet(string street)
        {
            Street = street;
        }
        public void SetLibrarian(string librarian)
        {
            Librarian = librarian;
        }
        public void SetNumberOfBooks(int books)
        {
            NumberOfBooks = books;
        }
        public void SetNumberOfHalls(int halls)
        {
            NumberOfHalls = halls;
        }
        public void SetNumberOfSeatsInTheHall(int seats)
        {
            NumberOfSeatsInTheHall = seats;
        }
        public void SetVisitorsPerDay(float visitors)
        {
            VisitorsPerDay = visitors;
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
