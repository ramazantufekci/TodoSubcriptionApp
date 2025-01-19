namespace TodoSubscriptionApp.Models;
public class UserSubscription
{
    public int Id {get;set;}
    public string UserId {get;set;} = string.Empty;
    public string SubscriptionType {get;set;} = "Free";
    public int MaxToDoLimit {get;set;} = 5;
}