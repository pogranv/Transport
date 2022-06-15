using System;
using System.Text;
using System.IO;

namespace EKRLib
{
    /// <summary>
    /// Базовый класс для всего транспорта.
    /// </summary>
    public abstract class Transport
    {
        protected string model;
        protected uint power;

        /// <summary>
        /// Конструктор класса Transport.
        /// Инициализирует необходимые свойства.
        /// </summary>
        /// <param name="model">Модель транспорта.</param>
        /// <param name="power">Мощность транспорта.</param>
        public Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Метод для логгирования текущего объекта в файл.
        /// </summary>
        /// <param name="path">Дирректория, в которой будет логгирование.</param>
        public virtual void ToFile(string path)
        {
            File.AppendAllText(path + "Transport.txt", ToString() + Environment.NewLine, Encoding.Unicode);
            return;
        }

        /// <summary>
        /// Проверка на коррекность модели.
        /// </summary>
        /// <param name="model">Модель, корректность которой нужно проверить.</param>
        /// <returns></returns>
        private bool IsCorrectModel(string model)
        {
            if (string.IsNullOrEmpty(model) || model.Length != 5)
                return false;

            foreach (var chr in model)
            {
                if (char.IsDigit(chr) || (char.IsUpper(chr) && char.IsLetter(chr)))
                    continue;

                return false;
            }
            return true;
        }

        /// <summary>
        /// Свойство модели транспорта.
        /// </summary>
        protected string Model {

            get => model; 

            set
            {
                if (!IsCorrectModel(value))
                {
                    throw new TransportException($"Недопустимая модель {Model}");
                }
                model = value;
            } 
        }

        /// <summary>
        /// Свойство мощности транспорта.
        /// </summary>
        protected uint Power 
        { 
            get => power; 
            set
            {
                if (value < 20)
                {
                    throw new TransportException("Мощность не может быть меньше 20 л.с.");
                }
                power = value;
            } 
        }

        /// <summary>
        /// Абстрактный метод.
        /// Показывает, что транспорт был создан корректно.
        /// </summary>
        /// <returns>Строка с видом транспорта и его звуком.</returns>
        public abstract string StartEngine();

        /// <summary>
        /// Переопределенный метод ToString.
        /// </summary>
        /// <returns>Возвращает строку информации о транспорте.</returns>
        public override string ToString()
        {
            return $"Model: {Model}, Power: {Power}";
        }
    }
}
