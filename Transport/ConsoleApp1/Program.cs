using System;
using EKRLib;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Поле, генерирующее рандомные числа.
        /// </summary>
        static Random s_rnd = new();

        /// <summary>
        /// Генерация случайной модели.
        /// </summary>
        /// <returns>Строка - модель.</returns>
        static string GetModel()
        {
            string model = "";
            for (int i = 0; i < 5; ++i)
            {
                if (s_rnd.Next(0, 2) == 0)
                    model += (char)s_rnd.Next('A', 'Z');
                else
                    model += s_rnd.Next(0, 10).ToString();
            }
            return model;
        }

        /// <summary>
        /// Генерация случайной мощности.
        /// </summary>
        /// <returns>Мощность.</returns>
        static uint GetPower()
        {
            return (uint)s_rnd.Next(10, 100);
        }
        /// <summary>
        /// Генерация случайной машины.
        /// </summary>
        /// <returns>Объект-машина.</returns>
        static Car GetCar()
        {
            while (true)
            {
                try
                {
                    var car = new Car(GetModel(), GetPower());
                    return car;
                } 
                catch (TransportException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Генерация случайной лодки.
        /// </summary>
        /// <returns>Объект-лодка.</returns>
        static MotorBoat GetMotorBoat()
        {
            while (true)
            {
                try
                {
                    var motorBoat = new MotorBoat(GetModel(), GetPower());
                    return motorBoat;
                }
                catch (TransportException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Генерация массива транспортных средств.
        /// </summary>
        /// <returns>Массив транспортных средств.</returns>
        public static Transport[] GetTransport()
        {
            Transport[] transport = new Transport[s_rnd.Next(6, 10)];

            for (int i = 0; i < transport.Length; i++)
            {
                // Равновероятностная случайная генерация.
                if (s_rnd.Next(0, 2) == 0)
                {
                    transport[i] = GetCar();
                }
                else
                {
                    transport[i] = GetMotorBoat();
                }
                Console.WriteLine(transport[i].StartEngine());
            }
            return transport;
        }

        /// <summary>
        /// Генерация транспортных средств, логгирование получившихся объектов.
        /// </summary>
        public static void StartProgram()
        {
            var transport = GetTransport();

            // Обнуление или создание пустых файлов для логгирования.
            string sep = Path.DirectorySeparatorChar.ToString();
            string dir = @$"..{sep}..{sep}..{sep}..{sep}";
            File.WriteAllText(dir+"Cars.txt", "", Encoding.Unicode);
            File.WriteAllText(dir+"MotorBoats.txt", "", Encoding.Unicode);

            foreach (var item in transport)
            {
                try
                {
                    item.ToFile(dir);
                }
                catch (Exception)
                {
                    Console.WriteLine("Не удалось осуществить запись в файл.");
                }
            }
        }

        /// <summary>
        /// Основная программа. Реализует одну итерацию описанного в ТЗ цикла,
        /// а также повтор решения.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        static void Main(string[] args)
        {
            // Повтор решения.
            do
            {
                StartProgram();

                Console.WriteLine("Продолжить выполнение программы? (Y/N)");

                // Анализ нажатой клавиши.
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Y)
                    {
                        break;
                    }
                    if (key.Key == ConsoleKey.N)
                    {
                        return;
                    }
                }

            } while (true);
        }
    }
}
