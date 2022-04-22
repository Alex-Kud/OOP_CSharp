using System;

namespace OOP_6.Exceptions
{
    internal class BookException : Exception
    {
        public BookException(string message, int year) :
            base("Ошибка из моего BookException исключения со следующим текстом: " + message)
        {
            Year = year;
        }

        public int Year { get; }
    }
}