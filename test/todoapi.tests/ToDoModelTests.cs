using todoapi.Models;

namespace todoapi.tests;

public class ToDoModelTests
{
    [Fact]
    public void CanChangeName()
    {
        var todoItem = new ToDoItem();
        todoItem.Name = "complete unit test";

        todoItem.Name="azure pipeline";

        Assert.Equal("azure pipeline", todoItem.Name);
    }
}