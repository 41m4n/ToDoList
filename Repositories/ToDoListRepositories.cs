using ToDoList.Models;
using ToDoList.Data;
using Microsoft.EntityFrameworkCore;


namespace ToDoList.Repositories
{
    public class ToDoListRepositories : IToDoListRepositories
    {
        private readonly ToDoListDbContext _db;

        public ToDoListRepositories(ToDoListDbContext db)
        {
            _db = db;
        }

        public async Task<List<ToDoListItem>> GetAllAsync()
        {
            return await _db.ToDoList.ToListAsync();
        }

        public async Task<ToDoListItem?> GetByIdAsync(int id)
        {
            return await _db.ToDoList.FindAsync(id);
        }

        public async Task AddAsync(ToDoListItem todo)
        {
            await _db.ToDoList.AddAsync(todo);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _db.ToDoList.FindAsync(id);
            if (item != null)
            {
                _db.ToDoList.Remove(item);
                await _db.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public Task UpdateAsync(ToDoListItem todo)
        {
             _db.ToDoList.Update(todo);
             return _db.SaveChangesAsync();
        }
    }
}
