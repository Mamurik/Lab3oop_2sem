using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3oop
{
    /// <summary>
    /// Представляет узел в связном списке.
    /// </summary>
    /// <typeparam name="T">Тип значения, хранящегося в узле.</typeparam>
    public class LinkedListNode<T>
    {
        /// <summary>
        /// Получает или задает значение узла.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Получает или задает ссылку на следующий узел в списке.
        /// </summary>
        public LinkedListNode<T> Next { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса LinkedListNode с указанным значением.
        /// </summary>
        /// <param name="value">Значение узла.</param>
        public LinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }
}