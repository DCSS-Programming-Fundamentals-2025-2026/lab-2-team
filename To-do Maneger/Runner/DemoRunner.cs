using System;
using To_Do_Manager.Models;
using To_Do_Manager.Services;

namespace To_Do_Manager.Runner
{
    internal class DemoRunner
    {
        public static void Run()
        {
            TaskStorage storage = new TaskStorage(10);
            TaskManager manager = new TaskManager(storage);

            while (true)
            {
                try
                {
                    Console.WriteLine("\n--- СПИСОК ЗАДАЧ ---");
                    Console.WriteLine("1. Створити задачу");
                    Console.WriteLine("2. Переглянути список задач");
                    Console.WriteLine("3. Позначити задачу виконаною");
                    Console.WriteLine("4. Видалити задачу");
                    Console.WriteLine("5. Статистика");
                    Console.WriteLine("6. Сортувати за пріоритетом");
                    Console.WriteLine("7. Сортувати за ID");
                    Console.WriteLine("0. Вихід");

                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Console.Write("Введіть ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Введіть назву: ");
                        string title = Console.ReadLine();

                        Console.Write("Введіть пріоритет: ");
                        int pr = int.Parse(Console.ReadLine());

                        manager.CreateTask(id, title, pr);
                    }
                    else if (choice == "2")
                    {
                        TodoTask[] all = storage.GetAll();
                        if (all.Length == 0)
                        {
                            Console.WriteLine("На даний момент задач немає");
                        }
                        else
                        {
                            for (int i = 0; i < all.Length; i++)
                            {
                                Console.WriteLine(i + ". " + all[i].GetSummary());
                            }
                        }
                    }
                    else if (choice == "3")
                    {
                        Console.Write("Введіть порядковий номер задачі: ");
                        int idx = int.Parse(Console.ReadLine());
                        manager.MarkAsDone(idx);
                    }
                    else if (choice == "4")
                    {
                        Console.Write("Введіть порядковий номер для видалення: ");
                        int idx = int.Parse(Console.ReadLine());
                        manager.DeleteTask(idx);
                    }
                    else if (choice == "5")
                    {
                        TodoTask[] tasks = storage.GetAll();
                        double p = TaskStatistics.CalculateCompletionPercentage(tasks);

                        Console.WriteLine("\n--- СТАТИСТИКА ---");
                        Console.WriteLine("Виконано задач: " + TaskStatistics.CountCompleted(tasks));
                        Console.WriteLine("Загальний прогрес: " + p + "%");
                    }
                    else if (choice == "6")
                    {
                        TodoTask[] tasks = storage.GetAll();
                        TaskSorting.SortByPriority(tasks);
                    }
                    else if (choice == "7")
                    {
                        TodoTask[] tasks = storage.GetAll();
                        TaskSorting.SortById(tasks);
                    }
                    else if (choice == "0")
                    {
                        Console.WriteLine("Вихід з програми...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Невірна команда. Спробуйте ще раз.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка, введено текст замість числа");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                }
            }
        }
    }
}