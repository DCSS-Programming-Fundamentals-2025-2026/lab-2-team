using System.Collections;
using To_Do_Manager.Models;

namespace To_Do_Manager.Comparers
{
    public class TaskPriorityComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            TodoTask t1 = x as TodoTask;
            TodoTask t2 = y as TodoTask;

            if (t1 != null && t2 != null)
            {
                return t1.GetPriority().CompareTo(t2.GetPriority());
            }
            return 0;
        }
    }
}