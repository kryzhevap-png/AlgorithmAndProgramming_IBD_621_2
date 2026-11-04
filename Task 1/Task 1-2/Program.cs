using System;

namespace Task_1_2
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Основная функция.
        /// </summary>
        /// <param name="args"> Список параметров. </param>
        static void Main(string[] args)
        {
            double x = GetNumber("Введите x = ");
            double y = GetNumber("Введите y = ");

            double arithmeticMean = GetArithmeticMeanOfCubes(x, y);
            double geometricMean = GetGeometricMeanOfModules(x, y);

            Console.WriteLine($"Среднее арифметическое кубов = {arithmeticMean}");
            Console.WriteLine($"Среднее геометрическое модулей = {geometricMean}");
        }

        /// <summary>
        /// Вычисляет среднее арифметическое кубов двух чисел.
        /// </summary>
        /// <param name="x"> Первое число. </param>
        /// <param name="y"> Второе число. </param>
        /// <returns> Среднее арифметическое кубов. </returns>
        private static double GetArithmeticMeanOfCubes(double x, double y)
        {
            return (x * x * x + y * y * y) / 2.0;
        }

        /// <summary>
        /// Вычисляет среднее геометрическое модулей двух чисел.
        /// </summary>
        /// <param name="x"> Первое число. </param>
        /// <param name="y"> Второе число. </param>
        /// <returns> Среднее геометрическое модулей. </returns>
        private static double GetGeometricMeanOfModules(double x, double y)
        {
            return Math.Sqrt(Math.Abs(x) * Math.Abs(y));
        }

        /// <summary>
        /// Считывает из консоли число.
        /// </summary>
        /// <param name="message"> Сообщение пользователю. </param>
        /// <returns> Считанное число. </returns>
        private static double GetNumber(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return double.Parse(input);
        }
    }
}