using System;

namespace Task_2_2
{
    /// <summary>
    /// Перечисление категорий билетов.
    /// </summary>
    enum TicketType
    {
        /// <summary>
        /// Бесплатный билет.
        /// </summary>
        Free = 0,

        /// <summary>
        /// Школьный билет.
        /// </summary>
        School,

        /// <summary>
        /// Взрослый билет.
        /// </summary>
        Adult,

        /// <summary>
        /// Пенсионный билет.
        /// </summary>
        Pensioner
    }

    /// <summary>
    /// Коды ошибок.
    /// </summary>
    enum CodeError
    {
        /// <summary>
        /// Успешное завершение программы.
        /// </summary>
        None = 0,

        /// <summary>
        /// Ошибка преобразования к целочисленному типу данных.
        /// </summary>
        ErrorInt,

        /// <summary>
        /// Возраст меньше нуля.
        /// </summary>
        ErrorLessZero
    }

    /// <summary>
    /// Основной класс программы.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        static void Main(string[] args)
        {
            int age = GetAge("Введите возраст человека = ");

            TicketType ticket = GetTicketType(age);

            switch (ticket)
            {
                case TicketType.Free:
                    {
                        Console.WriteLine("Категория билета: Бесплатно");
                        break;
                    }

                case TicketType.School:
                    {
                        Console.WriteLine("Категория билета: Школьный");
                        break;
                    }

                case TicketType.Adult:
                    {
                        Console.WriteLine("Категория билета: Взрослый");
                        break;
                    }

                case TicketType.Pensioner:
                    {
                        Console.WriteLine("Категория билета: Пенсионный");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Недопустимое значение");
                        break;
                    }
            }
        }

        /// <summary>
        /// Определяет категорию билета по возрасту человека.
        /// </summary>
        /// <param name="age">Возраст человека.</param>
        /// <returns>Категория билета.</returns>
        private static TicketType GetTicketType(int age)
        {
            if (age < 7)
            {
                return TicketType.Free;
            }
            else if (age < 18)
            {
                return TicketType.School;
            }
            else if (age <= 65)
            {
                return TicketType.Adult;
            }
            else
            {
                return TicketType.Pensioner;
            }
        }

        /// <summary>
        /// Получает и проверяет возраст человека.
        /// </summary>
        /// <param name="message">Сообщение пользователю.</param>
        /// <returns>Возраст человека.</returns>
        private static int GetAge(string message)
        {
            int result = GetInt(message);

            if (result < 0)
            {
                Console.WriteLine("Возраст не может быть отрицательным");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorLessZero);
            }

            return result;
        }

        /// <summary>
        /// Считывает целочисленное значение из консоли.
        /// </summary>
        /// <param name="message">Сообщение пользователю.</param>
        /// <returns>Целое число.</returns>
        private static int GetInt(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Недопустимое значение для целого типа данных");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorInt);
            }

            return result;
        }
    }
}