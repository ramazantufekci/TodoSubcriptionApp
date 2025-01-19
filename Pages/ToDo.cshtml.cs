using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoSubscriptionApp.Models;
using TodoSubscriptionApp.Data;

namespace TodoSubscriptionApp.Pages;

public class ToDoModel : PageModel
{
    private readonly AppDbContext _context;
    public ToDoModel(AppDbContext context)
    {
        _context = context;
    }

    public List<ToDoItem> ToDoItems {get;set;} = new();
    public string? ErrorMessage {get;set;}

    [BindProperty]
    public string Title {get;set;} = string.Empty;

    public string UserId {get;set;} = "user1";
    public string SubscriptionType { get; set; } = "Free"; // Mock subscription type
    public int MaxToDoLimit { get; set; } = 5;

    public void OnGet()
    {
        LoadUserSubscription();
        ToDoItems = _context.ToDoItems.Where(t => t.UserId == UserId).ToList();
    }

    public IActionResult OnPost()
    {
        LoadUserSubscription();
        var userTasks = _context.ToDoItems.Count(t => t.UserId == UserId);

        if (userTasks >= MaxToDoLimit)
        {
            ErrorMessage = "You have reached your ToDo limit for this subscription.";
            ToDoItems = _context.ToDoItems.Where(t => t.UserId == UserId).ToList();
            return Page();
        }

        var newItem = new ToDoItem { Title = Title, UserId = UserId };
        _context.ToDoItems.Add(newItem);
        _context.SaveChanges();

        return RedirectToPage();
    }

    public IActionResult OnGetUpdate(int id, bool completed)
    {
        var item = _context.ToDoItems.FirstOrDefault(t => t.Id == id && t.UserId == UserId);
        if (item != null)
        {
            item.IsCompleted = completed;
            _context.SaveChanges();
        }
        return RedirectToPage();
    }

    private void LoadUserSubscription()
    {
        var subscription = _context.UserSubscriptions.FirstOrDefault(s => s.UserId == UserId);
        if (subscription != null)
        {
            SubscriptionType = subscription.SubscriptionType;
            MaxToDoLimit = subscription.SubscriptionType == "Premium" ? 50 : 5;
        }
    }
}