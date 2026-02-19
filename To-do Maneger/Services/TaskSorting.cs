using To_Do_Manager.Models;

namespace To_Do_Manager.Services
{
    public static class TaskSorting
    {
        public static void SortByPriority(TodoTask[] tasks)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                for (int j = 0; j < tasks.Length - 1; j++)
                {
                    if (tasks[j].GetPriority() > tasks[j + 1].GetPriority())
                    {
                        TodoTask temp = tasks[j];
                        tasks[j] = tasks[j + 1];
                        tasks[j + 1] = temp;
                    }
                }
            }
        }

        public static void SortById(TodoTask[] tasks)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                for (int j = 0; j < tasks.Length - 1; j++)
                {
                    if (tasks[j].GetId() > tasks[j + 1].GetId())
                    {
                        TodoTask temp = tasks[j];
                        tasks[j] = tasks[j + 1];
                        tasks[j + 1] = temp;
                    }
                }
            }
        }
    }
}