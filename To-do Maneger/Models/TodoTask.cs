using System;

namespace To_Do_Manager.Models
{
    public class TodoTask
    {
        private int id;
        private string title;
        private bool isDone;
        private int priority;

        public TodoTask(int id, string title, int priority = 1)
        {
            this.id = id;
            this.title = title;
            this.isDone = false;
            this.priority = priority;
        }

        public int GetId()
        {
            return id;
        }

        public int GetPriority()
        {
            return priority;
        }

        public void MarkDone()
        {
            isDone = true;
        }

        public bool IsCompleted()
        {
            return isDone;
        }

        public string GetSummary()
        {
            string status = isDone ? "[✓]" : "[ ]";
            return $"{status} ID:{id} | Пріоритет:{priority} | {title}";
        }
    }
}