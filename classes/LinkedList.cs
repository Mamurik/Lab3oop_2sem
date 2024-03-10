using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3oop
{
    public class LinkedList<T> : ICollection<T>
    {
        private LinkedListNode<T> head; // Первый узел в связном списке
        private LinkedListNode<T> tail; // Последний узел в связном списке

        public int Count { get; private set; } // Количество элементов в связном списке
        public bool IsReadOnly => false; // Указывает, доступен ли связный список только для чтения

        public LinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void Add(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item);

            if (head == null)
            {
                // Если связный список пуст, новый узел становится и головным, и хвостовым
                head = newNode;
                tail = newNode;
            }
            else
            {
                // Если в связном списке уже есть узлы, добавляем новый узел в конец
                tail.Next = newNode;
                tail = newNode;
            }

            Count++;
        }

        public void Clear()
        {
            // Удаляем все узлы из связного списка
            head = null;
            tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                    return true;

                currentNode = currentNode.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (Count > array.Length - arrayIndex)
                throw new ArgumentException("Количество элементов в исходной коллекции больше, чем доступное пространство от arrayIndex до конца целевого массива.");

            LinkedListNode<T> currentNode = head;
            while (currentNode != null)
            {
                // Копируем значения узлов связного списка в массив
                array[arrayIndex] = currentNode.Value;
                arrayIndex++;
                currentNode = currentNode.Next;
            }
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> previousNode = null;
            LinkedListNode<T> currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    if (previousNode == null) // Удаляемый узел - первый в списке
                    {
                        head = currentNode.Next;
                        if (head == null) // Если список оказался пустым
                            tail = null;
                    }
                    else
                    {
                        // Удаляем текущий узел путем обновления ссылки на следующий узел у предыдущего узла
                        previousNode.Next = currentNode.Next;
                        if (currentNode.Next == null) // Удаляемый узел - последний в списке
                            tail = previousNode;
                    }

                    Count--;
                    return true;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> currentNode = head;
            while (currentNode != null)
            {
                // Перебираем связный список и возвращаем каждое значение
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}