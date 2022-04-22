using System;
using System.Windows.Forms;
using OOP_6.Exceptions;

namespace OOP_6
{
    /// <summary>
    ///     Класс сущности книга
    /// </summary>
    public abstract class Book
    {
        private int _year;
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 1900 || value > 2023) throw new BookException("Фантастический год издания книги!", value);
                _year = value;
            }
        }

        public string Type { get; set; }
    }

    /// <summary>
    ///     Класс сущности учебник
    /// </summary>
    internal class Textbook : Book
    {
        /// <summary>
        ///     конструктор с параметрами
        /// </summary>
        /// <param name="author">Автор</param>
        /// <param name="title">Название</param>
        /// <param name="publisher">Издательство</param>
        /// <param name="year">Год издания</param>
        /// <param name="type">Тип книги</param>
        /// <param name="subject">Предмет</param>
        /// <param name="clas">Класс</param>
        public Textbook(string author, string title, string publisher, int year, string type, string subject, int clas)
        {
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            Type = type;
            Subject = subject;
            Class = clas;
        }

        public string Subject { get; set; }
        public int Class { get; set; }

        /// <summary>
        ///     Чтение книги
        /// </summary>
        public void ReadBook()
        {
            MessageBox.Show(
                $"Книга открылась. Ты читаешь учебник {Title} по {Subject} за {Class} класс." +
                " Как много информаци... Это нужно запомнить. Ты стал умнее. Книга закрылась",
                "Чтение учебника",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        /// <summary>
        ///     Информация об объекте класса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Автор: {Author}" + Environment.NewLine +
                   $"Название: {Title}" + Environment.NewLine +
                   $"Издательство: {Publisher}" + Environment.NewLine +
                   $"Год: {Year}" + Environment.NewLine +
                   $"Тип: {Type}" + Environment.NewLine +
                   $"Предмет: {Subject}" + Environment.NewLine +
                   $"Класс: {Class}" + Environment.NewLine + Environment.NewLine;
        }
    }

    /// <summary>
    ///     Класс сущности художественная книга
    /// </summary>
    internal class ArtBook : Book
    {
        /// <summary>
        ///     Конструктор с параметрами
        /// </summary>
        /// <param name="author">Автор</param>
        /// <param name="title">Название</param>
        /// <param name="publisher">Издательство</param>
        /// <param name="year">Год издания</param>
        /// <param name="type">Тип книги</param>
        /// <param name="genre">Жанр</param>
        /// <param name="mainCharacter">Главный герой</param>
        public ArtBook(string author, string title, string publisher, int year, string type, string genre,
            string mainCharacter)
        {
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            Type = type;
            Genre = genre;
            MainCharacter = mainCharacter;
        }

        public string Genre { get; set; }
        public string MainCharacter { get; set; }

        /// <summary>
        ///     Чтение книги
        /// </summary>
        public void ReadBook()
        {
            MessageBox.Show(
                $"Книга {Title} открылась. Ты читаешь историю про {MainCharacter} в жанре {Genre}. " +
                $"Как интересно! {Author} хорошо пишет. Ты стал умнее. Книга закрылась",
                "Чтение книги",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        /// <summary>
        ///     Информация об объекте класса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Автор: {Author}" + Environment.NewLine +
                   $"Название: {Title}" + Environment.NewLine +
                   $"Издательство: {Publisher}" + Environment.NewLine +
                   $"Год: {Year}" + Environment.NewLine +
                   $"Тип: {Type}" + Environment.NewLine +
                   $"Жанр: {Genre}" + Environment.NewLine +
                   $"Главный герой: {MainCharacter}" + Environment.NewLine + Environment.NewLine;
        }
    }
}