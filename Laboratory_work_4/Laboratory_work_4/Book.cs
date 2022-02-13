using System;

namespace Laboratory_work_4
{
    abstract class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }

        public void ReadBook()
        {
            Console.WriteLine("You open book. You read book. Some information. Some information. Some information. You've become smart");
        }
    }

    class Textbook : Book
    {
        public string Subject { get; set; }
        public int Class { get; set; }
        public Textbook(string author, string title, string publisher, int year, string subject, int clas)
        {
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            Subject = subject;
            Class = clas;
        }
    }

    class ArtBook : Book
    {
        public string Genre { get; set; }
        public string MainCharacter { get; set; }
        public ArtBook(string author, string title, string publisher, int year, string genre, string mainCharacter)
        {
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            Genre = genre;
            MainCharacter = mainCharacter;
        }
    }

}
