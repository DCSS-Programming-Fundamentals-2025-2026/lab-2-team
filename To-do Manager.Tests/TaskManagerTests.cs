using NUnit.Framework;
using To_Do_Manager.Models;
using To_Do_Manager.Services;

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
            
            storage = new TaskStorage(10);
            manager = new TaskManager(storage);
        }

        [Test]
        public void CreateTask_ShouldAddTaskToStorage()
        {
            
            manager.CreateTask(1, "New Task", 2);

            
            Assert.IsTrue(storage.Exists(1));
        }

        [Test]
        public void MarkAsDone_ShouldChangeTaskStatus()
        {
            
            manager.CreateTask(1, "Task", 1);

            
            manager.MarkAsDone(0);

           
            Assert.IsTrue(storage.Exists(1));
            Assert.IsTrue(storageCountCompleted());
        }

        private bool storageCountCompleted()
        {
            return storageCountCompletedInternal() == 1;
        }

        private int storageCountCompletedInternal()
        {
            int completed = 0;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    if (storage.GetTask(i).IsCompleted())
                        completed++;
                }
                catch
                {
                    break;
                }
            }

            return completed;
        }

        [Test]
        public void DeleteTask_ShouldRemoveTask()
        {
            
            manager.CreateTask(1, "Delete me", 1);

           
            manager.DeleteTask(0);

            
            Assert.IsFalse(storage.Exists(1));
        }
    }
}