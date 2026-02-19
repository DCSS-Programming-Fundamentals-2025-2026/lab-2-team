using NUnit.Framework;
using To_Do_Manager.Services;
using To_Do_Manager.Models;

namespace To_Do_Manager.Tests
{
    [TestFixture]
    public class TaskManagerTests
    {
        private TaskStorage storage;
        private TaskManager manager;

        [SetUp]
        public void Setup()
        {
            storage = NewMethod();
            manager = new TaskManager(storage);
        }

        private static TaskStorage NewMethod()
        {
            return new TaskStorage();
        }

        [Test]
        public void CreateTask_ShouldAddTaskToStorage()
        {
            manager.CreateTask(1, "New Task", 2);

            var task = storage.GetTask(0);
            Assert.AreEqual("New Task", task.GetSummary().Split(' ').Last());
        }

        [Test]
        public void MarkAsDone_ShouldUpdateTaskStatus()
        {
            manager.CreateTask(1, "Complete me", 1);
            manager.MarkAsDone(0);

            Assert.IsTrue(storage.GetTask(0).IsCompleted());
        }

        [Test]
        public void DeleteTask_ShouldRemoveTask()
        {
            manager.CreateTask(1, "Task to delete", 1);
            manager.DeleteTask(0);

            Assert.AreEqual(0, storage.Count());
        }
    }
}
