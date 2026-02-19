using System;
using System.Collections;
using To_Do_Manager.Models;

namespace To_Do_Manager.Services
{
    public class TaskStorage : IEnumerable
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

        public void SetAt(int index, TodoTask task)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Невірний індекс");

            tasks[index] = task;
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

        public IEnumerator GetEnumerator()
        {
            return new TaskEnumerator(tasks, count);
        }
    }

    public class TaskEnumerator : IEnumerator
    {
        private TodoTask[] _tasks;
        private int _count;
        private int _position = -1;

        public TaskEnumerator(TodoTask[] tasks, int count)
        {
            _tasks = tasks;
            _count = count;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _count);
        }

        public void Reset()
        {
            _position = -1;
        }

        public object Current
        {
            get
            {
                if (_position < 0 || _position >= _count)
                    throw new InvalidOperationException();
                return _tasks[_position];
            }
        }
    }
}