using System;
using To_Do_Manager.Models;

namespace To_Do_Manager.Services
{
    public class TaskStorage
    {
        private TodoTask[] tasks;
        private int count;

        public TaskStorage(int capacity)
        {
            tasks = new TodoTask[capacity];
            count = 0;
        }

        public bool Exists(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (tasks[i].GetId() == id)
                    return true;
            }
            return false;
        }

        public void Add(TodoTask task)
        {
            if (Exists(task.GetId()))
                throw new InvalidOperationException("Задача з таким ID вже існує");

            if (count >= tasks.Length)
                throw new InvalidOperationException("Сховище заповнене");

            tasks[count] = task;
            count++;
        }

        public TodoTask GetTask(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Невірний індекс");

            return tasks[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Невірний індекс");

            for (int i = index; i < count - 1; i++)
            {
                tasks[i] = tasks[i + 1];
            }

            tasks[count - 1] = null;
            count--;
        }

        public int Count()
        {
            return count;
        }

        public TodoTask[] GetAll()
        {
            TodoTask[] result = new TodoTask[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = tasks[i];
            }

            return result;
        }
    }
}