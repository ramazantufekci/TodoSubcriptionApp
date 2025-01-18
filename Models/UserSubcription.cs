namespace TodoSubscriptionApp.Models;
public class UserSubscription
{
    public string UserId {get;set;} = string.Empty;
    public string SubscriptionType {get;set;} = "Free";
    public int MaxToDoLimit {get;set;} = 5;
}