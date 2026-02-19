using NUnit.Framework;
using To_Do_Manager.Models; 

[TestFixture]
public class TodoTaskTests
{
    [Test]
    public void Constructor_ShouldInitializeCorrectly()
    {
        var task = new TodoTask(1, "Test Task", 2);


        object value = Assert.AreEqual(1,
            task.GetId());
        Assert.AreEqual(2, task.GetPriority());
        Assert.IsFalse(task.IsCompleted());
    }

    [Test]
    public void MarkDone_ShouldSetIsCompletedTrue()
    {
        var task = new TodoTask(1, "Finish report", 3);
        task.MarkDone();

        Assert.IsTrue(task.IsCompleted());
    }

    [Test]
    public void GetSummary_ShouldReturnFormattedString()
    {
        var task = new TodoTask(1, "Write code", 3);
        string summary = task.GetSummary();

        
        Assert.IsTrue(summary.Contains("ID:1"));
        Assert.IsTrue(summary.Contains("Пріоритет:3"));
        Assert.IsTrue(summary.Contains("Write code"));
    }
}