using To_Do_Manager.Models;

namespace To_Do_Manager.Services
{
    public static class TaskStatistics
    {
        public static int CountCompleted(TodoTask[] tasks)
        {
            int completed = 0;

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].IsCompleted())
                    completed++;
            }

            return completed;
        }

        public static double CalculateCompletionPercentage(TodoTask[] tasks)
        {
            if (tasks.Length == 0)
                return 0;

            int completed = CountCompleted(tasks);

            return (double)completed / tasks.Length * 100;
        }
    }
}