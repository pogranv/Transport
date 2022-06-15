using System;
using EKRLib;
using System.IO;
using System.Text;

namespace EKRLib
{
    /// <summary>
    /// Класс, отвечающий за создание и поддержку объектов машин.
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Конструктор класса Car.
        /// Инициализирует необходимые свойства.
        /// </summary>
        /// <param name="model">Модель машины.</param>
        /// <param name="power">Мощность машины.</param>
        public Car(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Метод для логгирования текущего объекта в файл.
        /// </summary>
        /// <param name="path">Дирректория, в которой будет логгирование.</param>
        public override void ToFile(string path)
        {
            File.AppendAllText(path + "Cars.txt", ToString() + Environment.NewLine, Encoding.Unicode);
            // File.AppendAllText("..\\..\\..\\..\\Cars.txt", ToString() + Environment.NewLine, Encoding.Unicode);
            return;
        }

        /// <summary>
        /// Показывает, что машина была создана корректно.
        /// </summary>
        /// <returns>Строка с видом транспорта и его звуком.</returns>
        public override string StartEngine()
        {
            return $"{Model} : Vroom";
        }

        /// <summary>
        /// Переопределенный метод ToString.
        /// </summary>
        /// <returns>Возвращает строку информации о машине.</returns>
        public override string ToString()
        {
            return "Car. " + base.ToString();
        }
    }
}
