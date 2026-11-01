using System;

namespace Task_2_1
{
    /// <summary>
    /// Перечисление вариантов расчёта.
    /// </summary>
    enum ActionType
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        None = 0,

        /// <summary>
        /// Расчёт характеристик цилиндра.
        /// </summary>
        Cylinder,

        /// <summary>
        /// Расчёт характеристик конуса.
        /// </summary>
        Cone
    }

    /// <summary>
    /// Перечисление кодов ошибок.
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
        /// Ошибка преобразования к перечислимому типу данных.
        /// </summary>
        ErrorEnum,

        /// <summary>
        /// Значение меньше или равно нулю.
        /// </summary>
        ErrorLessOrEqualZero,

        /// <summary>
        /// Ошибка предметной области.
        /// </summary>
        ErrorDomain
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
            ActionType action = GetAction(
                "Что вы хотите посчитать? Cylinder или Cone: ");

            switch (action)
            {
                case ActionType.Cylinder:
                    {
                        double radius = GetRadius(
                            "Введите радиус основания цилиндра = ");

                        double height = GetHeight(
                            "Введите высоту цилиндра = ");

                        double volume = GetCylinderVolume(radius, height);
                        double surface = GetCylinderSurface(radius, height);

                        Console.WriteLine($"Объём цилиндра равен {volume}");
                        Console.WriteLine($"Площадь полной поверхности цилиндра равна {surface}");
                        break;
                    }

                case ActionType.Cone:
                    {
                        double radius = GetRadius(
                            "Введите радиус основания конуса = ");

                        double generatrix = GetGeneratrix(radius);

                        double height = GetConeHeight(radius, generatrix);
                        double volume = GetConeVolume(radius, height);
                        double surface = GetConeSurface(radius, generatrix);

                        Console.WriteLine($"Высота конуса равна {height}");
                        Console.WriteLine($"Объём конуса равен {volume}");
                        Console.WriteLine($"Площадь полной поверхности конуса равна {surface}");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Недопустимое значение действия");
                        break;
                    }
            }
        }

        /// <summary>
        /// Рассчитывает объём цилиндра.
        /// </summary>
        /// <param name="radius">Радиус основания цилиндра.</param>
        /// <param name="height">Высота цилиндра.</param>
        /// <returns>Объём цилиндра.</returns>
        private static double GetCylinderVolume(double radius, double height)
        {
            return Math.PI * radius * radius * height;
        }

        /// <summary>
        /// Рассчитывает площадь полной поверхности цилиндра.
        /// </summary>
        /// <param name="radius">Радиус основания цилиндра.</param>
        /// <param name="height">Высота цилиндра.</param>
        /// <returns>Площадь полной поверхности цилиндра.</returns>
        private static double GetCylinderSurface(double radius, double height)
        {
            return 2 * Math.PI * radius * (radius + height);
        }

        /// <summary>
        /// Рассчитывает высоту конуса.
        /// </summary>
        /// <param name="radius">Радиус основания конуса.</param>
        /// <param name="generatrix">Образующая конуса.</param>
        /// <returns>Высота конуса.</returns>
        private static double GetConeHeight(double radius, double generatrix)
        {
            return Math.Sqrt(generatrix * generatrix - radius * radius);
        }

        /// <summary>
        /// Рассчитывает объём конуса.
        /// </summary>
        /// <param name="radius">Радиус основания конуса.</param>
        /// <param name="height">Высота конуса.</param>
        /// <returns>Объём конуса.</returns>
        private static double GetConeVolume(double radius, double height)
        {
            return Math.PI * radius * radius * height / 3;
        }

        /// <summary>
        /// Рассчитывает площадь полной поверхности конуса.
        /// </summary>
        /// <param name="radius">Радиус основания конуса.</param>
        /// <param name="generatrix">Образующая конуса.</param>
        /// <returns>Площадь полной поверхности конуса.</returns>
        private static double GetConeSurface(double radius, double generatrix)
        {
            return Math.PI * radius * (radius + generatrix);
        }

        /// <summary>
        /// Считывает выбранное действие пользователя.
        /// </summary>
        /// <param name="message">Сообщение пользователю.</param>
        /// <returns>Выбранное действие.</returns>
        private static ActionType GetAction(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (!Enum.TryParse(input, ignoreCase: true, out ActionType result)
                || !Enum.IsDefined(typeof(ActionType), result)
                || result == ActionType.None)
            {
                Console.WriteLine("Недопустимое значение действия");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorEnum);
            }

            return result;
        }

        /// <summary>
        /// Получает радиус основания.
        /// </summary>
        /// <param name="message">Сообщение пользователю.</param>
        /// <returns>Радиус основания.</returns>
        private static double GetRadius(string message)
        {
            double result = GetDouble(message);

            if (result <= 0)
            {
                Console.WriteLine("Радиус должен быть больше нуля");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorLessOrEqualZero);
            }

            return result;
        }

        /// <summary>
        /// Получает высоту цилиндра.
        /// </summary>
        /// <param name="message">Сообщение пользователю.</param>
        /// <returns>Высота цилиндра.</returns>
        private static double GetHeight(string message)
        {
            double result = GetDouble(message);

            if (result <= 0)
            {
                Console.WriteLine("Высота должна быть больше нуля");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorLessOrEqualZero);
            }

            return result;
        }

        /// <summary>
        /// Получает образующую конуса.
        /// </summary>
        /// <param name="radius">Радиус основания конуса.</param>
        /// <returns>Образующая конуса.</returns>
        private static double GetGeneratrix(double radius)
        {
            double result = GetDouble("Введите образующую конуса = ");

            if (result <= radius)
            {
                Console.WriteLine("Образующая должна быть больше радиуса основания");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorDomain);
            }

            return result;
        }

        /// <summary>
        /// Считывает вещественное число из консоли.
        /// </summary>
        /// <param name="message">Сообщение пользователю.</param>
        /// <returns>Вещественное число.</returns>
        private static double GetDouble(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (!double.TryParse(input, out double result) || !double.IsFinite(result))
            {
                Console.WriteLine("Недопустимое значение для вещественного типа данных");
                Console.ReadLine();
                Environment.Exit((int)CodeError.ErrorDouble);
            }

            return result;
        }
    }
}