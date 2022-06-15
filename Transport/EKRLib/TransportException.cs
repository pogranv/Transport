using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    /// <summary>
    /// Класс, реализующий пользовательский тип исключения для класса Transport.
    /// </summary>
    [Serializable]
    public class TransportException : Exception
    {
        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public TransportException() { }
        /// <summary>
        /// Конструктор с одним параметром сообщения.
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо передать.</param>
        public TransportException(string message) : base(message) { }
        /// <summary>
        /// Конструктор с двумя параметрами: сообщением и агрегируемым исключением.
        /// </summary>
        /// <param name="message">Сообщение, которое необходимо передать.</param>
        /// <param name="inner">Агрегируемое исключение.</param>
        public TransportException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Конструктор с двумя параметрами для сериализации.
        /// </summary>
        /// <param name="info">Информация для сериализации.</param>
        /// <param name="context">Контекст сериализации.</param>
        protected TransportException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
