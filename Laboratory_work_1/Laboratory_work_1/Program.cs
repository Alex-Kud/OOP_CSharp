using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_work_1
{
    class Program {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа № 1.\nКласс. Создание объекта. Работа с консолью\nВариант 1\nАгапова, Кудашов\n\n");
            Library lib = new Library();
            while (true)
            {
                PrintMainMenu();
                int typeСommand = -1;
                typeСommand = Convert.ToInt32(Console.ReadLine());
                while (typeСommand < 1 || typeСommand > 6)
                {
                    Console.WriteLine("Ошибка! Введите значение снова");
                    typeСommand = Convert.ToInt32(Console.ReadLine());
                }
                switch (typeСommand)
                {
                    case 1:
                        Console.WriteLine("-----ToString is used:-----");
                        Console.WriteLine(lib.ToString());
                        break;
                    case 2:
                        Console.WriteLine("-----Direct access to the field:-----");
                        Console.WriteLine("Library name: " + lib.Name);
                        Console.WriteLine("Street: " + lib.Street);
                        Console.WriteLine("Last name of the librarian: " + lib.Librarian);
                        Console.WriteLine("Number of books in the library: " + lib.NumberOfBooks);
                        Console.WriteLine("Number of halls in the library: " + lib.NumberOfHalls);
                        Console.WriteLine("Number of seats in the hall: " + lib.NumberOfSeatsInTheHall);
                        Console.WriteLine("Average number of visitors per day: " + lib.VisitorsPerDay + '\n');
                        break;
                    case 3:
                        Console.WriteLine("-----Information output using the method-----");
                        lib.ShowName();
                        break;
                    case 4:
                        Console.WriteLine("-----Output in hexadecimal system-----");
                        Console.WriteLine("{0:x}", lib.NumberOfBooks);
                        break;
                    case 5:
                        Console.WriteLine("Для продолжения работы введите одну из команд:");
                        Console.WriteLine("1 - изменить название");
                        Console.WriteLine("2 - изменить количество книг");
                        Console.WriteLine("3 - изменить среднее количество посетителей в день");
                        int typeValue = -1;
                        typeValue = Convert.ToInt32(Console.ReadLine());
                        while (typeValue < 1 || typeValue > 3)
                        {
                            Console.WriteLine("Ошибка! Введите значение снова");
                            typeValue = Convert.ToInt32(Console.ReadLine());
                        }
                        switch (typeValue)
                        {
                            case 1:
                                Console.WriteLine("Введите новое значение названия библиотеки");
                                string name = Console.ReadLine();
                                lib.SetName(name);
                                break;
                            case 2:
                                Console.WriteLine("Введите новое значение количества книг в библиотеке");
                                int books = Convert.ToInt32(Console.ReadLine());
                                lib.SetNumberOfBooks(books);
                                break;
                            case 3:
                                Console.WriteLine("Введите новое значение среднего количества посетителей в день");
                                float visitors = (float) Convert.ToDouble(Console.ReadLine());
                                lib.SetVisitorsPerDay(visitors);
                                break;
                        }
                        break;
                    case 6:
                        return;
                    default:
                        return;
                }
            }
        }

        static void PrintMainMenu()
        {
            Console.WriteLine("Для продолжения работы введите одну из команд:");
            Console.WriteLine("1 - использование переопределенного ToString");
            Console.WriteLine("2 - использование непосредственного обращения к полю");
            Console.WriteLine("3 - использование специального метода");
            Console.WriteLine("4 - вывод в шестнадцатеричном представлении");
            Console.WriteLine("5 - замена значения");
            Console.WriteLine("6 - завершение работы программы");
        }
    }
}
