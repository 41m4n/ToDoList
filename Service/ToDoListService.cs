using ToDoList.Models;

namespace ToDoList.Service;

public class ToDoListService
{
    public async Task<List<ToDoListItem>> GetToDoListItemsAsync()
    {
        return new List<ToDoListItem>();
    }
}