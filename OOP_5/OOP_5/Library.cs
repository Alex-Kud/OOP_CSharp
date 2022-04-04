using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace OOP_5
{
    public class Library
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
            Name = "Неизвестно";
            Street = "Неизвестно";
            Librarian = "Неизвестно";
            NumberOfBooks = 0;
            NumberOfHalls = 0;
            NumberOfSeatsInTheHall = 0;
            VisitorsPerDay = 0f;
            QuantityLibraries++;
        }
        public Library(string name, string street, string librarian, int halls, int seats, float visitors)
        {
            Name = name;
            Street = street;
            Librarian = librarian;
            NumberOfBooks = 0;
            NumberOfHalls = halls;
            NumberOfSeatsInTheHall = seats;
            VisitorsPerDay = visitors;
            QuantityLibraries++;
        }

        public override string ToString()
        {
            return $"Название: {Name}" + Environment.NewLine +
                   $"Улица: {Street}" + Environment.NewLine +
                   $"Фамилия библиотекаря: {Librarian}" + Environment.NewLine +
                   $"Количество книг: {NumberOfBooks}" + Environment.NewLine +
                   $"Количество читальных залов: {NumberOfHalls}" + Environment.NewLine +
                   $"Количество мест в зале: {NumberOfSeatsInTheHall}" + Environment.NewLine +
                   $"Среднее количество посетителей в день: {VisitorsPerDay}" + Environment.NewLine + Environment.NewLine;
        }
        public void ShowName()
        {
            Console.WriteLine("Название библиотеки: " + Name);
        }

        public static Library operator +(Library lib, Book book)
        {
            if (!lib.Books.Any(b => b.Title == book.Title 
                                    && b.Publisher == book.Publisher))
            {
                lib.Books.Add(book);
                lib.NumberOfBooks = lib.Books.Count;
            }
            else
            {
                MessageBox.Show(
                    "Книга уже существует. Нельзя добавлять одну и ту же книгу дважды",
                    "Ошибка добавления книги",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            return lib;
        }
        public static Library operator -(Library lib, Book book)
        {
            lib.Books.Remove(book);
            lib.NumberOfBooks = lib.Books.Count;
            return lib;
        }
    }
}