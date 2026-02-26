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

            TodoTask[] tasks = new TodoTask[storage.Count()];
            for (int i = 0; i < storage.Count(); i++) tasks[i] = storage.GetTask(i);

            int completedCount = TaskStatistics.CountCompleted(tasks);

            Assert.AreEqual(1, completedCount, "Статистика має показувати 1 виконане завдання");
        }

        [Test]
        public void RemoveTask_ShouldShiftArrayCorrectly()
        {
            manager.CreateTask(1, "Task 1", 1);
            manager.CreateTask(2, "Task 2", 2);
            manager.CreateTask(3, "Task 3", 3);

            manager.DeleteTask(1); 

            Assert.Multiple(() =>
            {
                Assert.AreEqual(2, storage.Count(), "Кількість елементів має зменшитися");
               
                Assert.AreEqual(3, storage.GetTask(1).GetId(), "Елементи мають зсунутися вліво");
            });
        }
    }
}