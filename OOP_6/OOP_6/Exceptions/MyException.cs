using System;

namespace OOP_6
{
    internal class MyException : InvalidCastException
    {
        public MyException(string message, DateTime date) :
            base("Ошибка из моего исключения со следующим текстом: " + message)
        {
            Date = date;
        }

        public DateTime Date { get; }
    }
}