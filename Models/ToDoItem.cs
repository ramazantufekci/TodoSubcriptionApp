namespace TodoSubscriptionApp.Models;
public class ToDoItem
{
    public int Id {get;set;}
    public string Title {get;set;}
    public bool IsCompleted {get;set;}
    public string UserId {get;set;}
}