
using System;

namespace Task_2_3
{
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
        /// Ошибка преобразования к вещественному типу данных.
        /// </summary>
        ErrorDouble,

        /// <summary>
        /// Ошибка переполнения вещественного типа данных.
        /// </summary>
        ErrorOverflow
    }

    /// <summary>
    /// Точка входа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Список формальных аргументов.</param>
        static void Main(string[] args)
        {
            double a = GetDouble("Введите a = ");
            double b = GetDouble("Введите b = ");
            double c = GetDouble("Введите c = ");

            if (a < b)
            {
                if (b < c)
                {
                    DoubleNumbers(ref a, ref b, ref c);
                }
                else
                {
                    GetAbsoluteValues(ref a, ref b, ref c);
                }
            }
            else
            {
                if (a > b)
                {
                    if (b > c)
                    {
                        SquareNumbers(ref a, ref b, ref c);
                    }
                    else
                    {
                        GetAbsoluteValues(ref a, ref b, ref c);
                    }
                }
                else
                {
                    GetAbsoluteValues(ref a, ref b, ref c);
                }
            }

            PrintResult(a, b, c);
        }

        /// <summary>
        /// Удваивает три вещественных числа.
        /// </summary>
        /// <param name="a">Первое число.</param>
        /// <param name="b">Второе число.</param>
        /// <param name="c">Третье число.</param>
        private static void DoubleNumbers(ref double a, ref double b, ref double c)
        {
            a = a * 2;
            b = b * 2;
            c = c * 2;
        }

        /// <summary>
        /// Возводит три вещественных числа в квадрат.
        /// </summary>
        /// <param name="a">Первое число.</param>
        /// <param name="b">Второе число.</param>
        /// <param name="c">Третье число.</param>
        private static void SquareNumbers(ref double a, ref double b, ref double c)
        {
            a = a * a;
            b = b * b;
            c = c * c;
        }

        /// <summary>
        /// Находит абсолютные значения трёх вещественных чисел.
        /// </summary>
        /// <param name="a">Первое число.</param>
        /// <param name="b">Второе число.</param>
        /// <param name="c">Третье число.</param>
        private static void GetAbsoluteValues(ref double a, ref double b, ref double c)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);
        }

        /// <summary>
        /// Проверяет результаты вычислений и выводит их на экран.
        /// </summary>
        /// <param name="a">Первое число.</param>
        /// <param name="b">Второе число.</param>
        /// <param name="c">Третье число.</param>
        /// <remarks>
        /// Аварийно закрывает программу при переполнении
        /// с кодом ошибки ErrorOverflow.
        /// </remarks>
        private static void PrintResult(double a, double b, double c)
        {
            if (!double.IsFinite(a) ||
                !double.IsFinite(b) ||
                !double.IsFinite(c))
            {
                Console.WriteLine("Ошибка: произошло переполнение типа double.");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorOverflow);
            }

            Console.WriteLine($"Результат: a = {a}, b = {b}, c = {c}");
        }

        /// <summary>
        /// Считывает вещественное число из консоли.
        /// </summary>
        /// <param name="message">Сообщение пользователю.</param>
        /// <returns>Вещественное число.</returns>
        /// <remarks>
        /// Аварийно закрывает программу при неправильном вводе
        /// с кодом ошибки ErrorDouble.
        /// </remarks>
        private static double GetDouble(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (!double.TryParse(input, out double result) ||
                !double.IsFinite(result))
            {
                Console.WriteLine("Недопустимое значение для вещественного типа данных.");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorDouble);
            }

            return result;
        }
    }
}