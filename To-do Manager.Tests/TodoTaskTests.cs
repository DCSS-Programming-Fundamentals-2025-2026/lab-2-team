using NUnit.Framework;
using To_Do_Manager.Models;

namespace To_Do_Manager.Tests
{
    [TestFixture]
    public class TodoTaskTests
    {
        [Test]
        public void MarkDone_ShouldSetCompletedTrue()
        {
            
            var task = new TodoTask(1, "Test Task", 2);

            
            task.MarkDone();

            
            Assert.IsTrue(task.IsCompleted());
        }

        [Test]
        public void GetSummary_ShouldReturnCorrectFormat()
        {
            
            var task = new TodoTask(5, "Write code", 3);

            
            var summary = task.GetSummary();

            
            Assert.IsTrue(summary.Contains("ID: 5"));
            Assert.IsTrue(summary.Contains("Пріоритет: 3"));
            Assert.IsTrue(summary.Contains("Write code"));
        }
    }
}