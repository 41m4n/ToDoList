using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface IToDoListRepositories
    {
        Task<List<ToDoListItem>> GetAllAsync();
        Task<ToDoListItem?> GetByIdAsync(int id);
        Task AddAsync(ToDoListItem todo);
        Task UpdateAsync(ToDoListItem todo);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}