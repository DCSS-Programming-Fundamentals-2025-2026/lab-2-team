using To_Do_Manager.Models;

namespace To_Do_Manager.Services
{
    public class TaskManager
    {
        private TaskStorage storage;

        public TaskManager(TaskStorage storage)
        {
            this.storage = storage;
        }

        public void CreateTask(int id, string title, int priority)
        {
            TodoTask task = new TodoTask(id, title, priority);
            storage.Add(task);
        }

        public void MarkAsDone(int index)
        {
            storage.GetTask(index).MarkDone();
        }

        public void DeleteTask(int index)
        {
            storage.RemoveAt(index);
        }
    }
}