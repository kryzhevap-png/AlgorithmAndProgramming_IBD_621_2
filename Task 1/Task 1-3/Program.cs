using System;

namespace Task_1_3
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
            double stiffness = GetNumber("Введите коэффициент жёсткости k (Н/м) = ");
            double extension = GetNumber("Введите растяжение x (м) = ");

            double potentialEnergy = GetPotentialEnergy(stiffness, extension);

            Console.WriteLine($"Потенциальная энергия пружины = {potentialEnergy} Дж");
        }

        /// <summary>
        /// Вычисляет потенциальную энергию растянутой пружины.
        /// </summary>
        /// <param name="stiffness"> Коэффициент жёсткости пружины. </param>
        /// <param name="extension"> Растяжение пружины. </param>
        /// <returns> Потенциальная энергия пружины. </returns>
        private static double GetPotentialEnergy(double stiffness, double extension)
        {
            return stiffness * extension * extension / 2.0;
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
