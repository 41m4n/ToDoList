using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Service;

public class ToDoListService
{
    private IToDoListRepositories _toDoListRepositories;

    public ToDoListService(IToDoListRepositories toDoListRepositories)
    {
        _toDoListRepositories = toDoListRepositories;
    }
    
    public async Task AddToDoListItemAsync(ToDoListItem newItem)
    {
        await _toDoListRepositories.AddAsync(newItem);
    }
    public async Task<List<ToDoListItem>> GetToDoListItemsAsync()
    {
        return await _toDoListRepositories.GetAllAsync();
    }

    public async Task<List<ToDoListItem>> GetFilteredToDoListItemsAsync(bool? isCompleted)
    {
        var allItems = await _toDoListRepositories.GetAllAsync();
        if (isCompleted == null)
        {
            return allItems;
        }
        return allItems.Where(item => item.IsCompleted == isCompleted).ToList();
    }

    public async Task DeleteToDoListItemAsync(int id)
    {
        await _toDoListRepositories.DeleteAsync(id);
    }

    public async Task UpdateToDoListItemAsync(ToDoListItem item)
    {
        await _toDoListRepositories.UpdateAsync(item);
    }
}