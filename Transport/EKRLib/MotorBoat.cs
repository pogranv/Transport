using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EKRLib
{
    /// <summary>
    /// Класс, отвечающий за создание и поддержку объектов лодок.
    /// </summary>
    public class MotorBoat : Transport
    {

        /// <summary>
        /// Конструктор класса MotorBoat.
        /// Инициализирует необходимые свойства.
        /// </summary>
        /// <param name="model">Модель лодки.</param>
        /// <param name="power">Мощность лодки.</param>
        public MotorBoat(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Метод для логгирования текущего объекта в файл.
        /// </summary>
        /// <param name="path">Дирректория, в которой будет логгирование.</param>
        public override void ToFile(string path)
        {
            File.AppendAllText(path + "MotorBoats.txt", ToString() + Environment.NewLine, Encoding.Unicode);
            return;
        }



        /// <summary>
        /// Показывает, что лодка была создана корректно.
        /// </summary>
        /// <returns>Строка с видом транспорта и его звуком.</returns>
        public override string StartEngine()
        {
            return $"{Model} : Brrrbrr";
        }

        /// <summary>
        /// Переопределенный метод ToString.
        /// </summary>
        /// <returns>Возвращает строку информации о лодке..</returns>
        public override string ToString()
        {
            return "MotorBoat. " + base.ToString();
        }
    }
}
