using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Lab3oop
{
    /// <summary>
    /// Узел списка (List node)
    /// </summary>

    /// <summary>
    /// Пример использования коллекции 
    /// </summary>
    public partial class MainWindow : Window
    {
        private LinkedList<string> linkedList;

        public MainWindow()
        {
            InitializeComponent();

            // Создание и заполнение списка 
            linkedList = new LinkedList<string>
            {
                "Apple",
                "Banana",
                "Cherry"
            };
        }

        /// <summary>
        /// Добавление элемента в список
        /// </summary>
        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            string newItem = "New Item";
            linkedList.Add(newItem);
            AddToLog("Добавленный элемент: " + newItem);
        }

        /// <summary>
        /// Удаление элемента из списка 
        /// </summary>
        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            string itemToRemove = "Banana";
            bool removed = linkedList.Remove(itemToRemove);

            if (removed)
                AddToLog("Удаленный Элемент: " + itemToRemove);
            else
                AddToLog("Элемент не найден:: " + itemToRemove);
        }

        /// <summary>
        /// Итерация по элементам списка 
        /// </summary>
        private void Iterate_Click(object sender, RoutedEventArgs e)
        {
            AddToLog("Элементы связанного списка:");

            foreach (string item in linkedList)
            {
                AddToLog(item);
            }
        }

        /// <summary>
        /// Выполнение операции в зависимости от выбранного элемента и операции 
        /// </summary>
        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListBoxItem selectedItem = (ListBoxItem)ItemsListBox.SelectedItem;
                if (selectedItem == null)
                {
                    throw new InvalidOperationException("Не выбран элемент из списка.");
                }

                string selectedValue = selectedItem.Content.ToString();

                ComboBoxItem selectedOperation = (ComboBoxItem)OperationComboBox.SelectedItem;
                if (selectedOperation == null)
                {
                    throw new InvalidOperationException("Не выбрана операция из выпадающего списка.");
                }

                string operation = selectedOperation.Content.ToString();

                switch (operation)
                {
                    case "Add":
                        linkedList.Add(selectedValue);
                        AddToLog("Добавленный Элемент: " + selectedValue);
                        break;
                    case "Remove":
                        bool removed = linkedList.Remove(selectedValue);

                        if (removed)
                            AddToLog("Удаленный Элемент: " + selectedValue);
                        else
                            AddToLog("Элемент не найден: " + selectedValue);
                        break;
                    case "Iterate":
                        AddToLog("Элементы связанного списка:");

                        foreach (string item in linkedList)
                        {
                            AddToLog(item);
                        }
                        break;
                    case "Copy To Array":
                        string[] array = new string[linkedList.Count];
                        linkedList.CopyTo(array, 0);
                        AddToLog("Скопированные элементы в массив:");

                        foreach (string item in array)
                        {
                            AddToLog(item);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения и вывод сообщения об ошибке 
                AddToLog("Ошибка: " + ex.Message);
            }
        }

        /// <summary>
        /// Копирование элементов списка в массив 
        /// </summary>
        private void CopyToArray_Click(object sender, RoutedEventArgs e)
        {
            string[] array = new string[linkedList.Count];
            linkedList.CopyTo(array, 0);

            AddToLog("Скопированные элементы в массив:");

            foreach (string item in array)
            {
                AddToLog(item);
            }
        }

        /// <summary>
        /// Отображение сообщения в TextBox 
        /// </summary>
        private void AddToLog(string logMessage)
        {
            LogTextBox.AppendText(logMessage + "\n");
        }
    }
}