using System;

namespace laba_8
{
    public class Library : IComparable<Library>
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Librarian { get; set; }
        public int NumberOfBooks { get; set; }
        public int NumberOfHalls { get; set; }
        public int NumberOfSeatsInTheHall { get; set; }
        public float VisitorsPerDay { get; set; }
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
        public override string ToString()
        {
            return $"Library name: {Name}" + Environment.NewLine +
                   $"Street: {Street}" + Environment.NewLine +
                   $"Last name of the librarian: {Librarian}" + Environment.NewLine +
                   $"Number of books in the library: {NumberOfBooks}" + Environment.NewLine +
                   $"Number of halls in the library: {NumberOfHalls}" + Environment.NewLine +
                   $"Number of seats in the hall: {NumberOfSeatsInTheHall}" + Environment.NewLine +
                   $"Average number of visitors per day: {VisitorsPerDay}" + Environment.NewLine + Environment.NewLine;
        }
        public void ShowName()
        {
            Console.WriteLine("Library name: " + Name);
        }

        public int CompareTo(Library? other)
        {
            if (other is null) throw new ArgumentException("Некорректное значение параметра");
            return Name.CompareTo(other.Name);
        }
    }
}