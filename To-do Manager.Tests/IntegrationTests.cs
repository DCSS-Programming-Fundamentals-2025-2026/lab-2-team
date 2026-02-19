using NUnit.Framework;
using To_Do_Manager.Models;
using To_Do_Manager.Services;

namespace To_Do_Manager.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        private TaskStorage storage;
        private TaskManager manager;

        [SetUp]
        public void Setup()
        {
            
            storage = new TaskStorage(10);
            manager = new TaskManager(storage);
        }

        [Test]
        public void FullScenario_CreateMarkDoneAndCheckStats()
        {
            

            
            manager.CreateTask(1, "Task 1", 1);
            manager.CreateTask(2, "Task 2", 2);

            manager.MarkAsDone(0);

            TodoTask[] tasks = new TodoTask[2];
            tasks[0] = storage.GetTask(0);
            tasks[1] = storage.GetTask(1);

            int completed = TaskStatistics.CountCompleted(tasks);

           
            Assert.AreEqual(1, completed);
        }

        [Test]
        public void RemoveTask_ShouldShiftArrayCorrectly()
        {
            
            manager.CreateTask(1, "Task1", 1);
            manager.CreateTask(2, "Task2", 2);
            manager.CreateTask(3, "Task3", 3);

            
            manager.DeleteTask(1);

            
            Assert.AreEqual(3, storage.GetTask(1).GetId());
        }

        [Test]
        public void AddDuplicateId_ShouldThrowException()
        {
            
            manager.CreateTask(1, "Task1", 1);

            
            Assert.Throws<System.InvalidOperationException>(() =>
            {
                manager.CreateTask(1, "Duplicate", 2);
            });
        }
    }
}