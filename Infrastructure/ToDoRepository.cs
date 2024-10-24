using Application.Repository;
using Infrastructure.Dat;
using Microsoft.EntityFrameworkCore;
using ToDoList.Core.Entities;


namespace Infrastructure
{
    class ToDoRepository : IToDoRepository

  {
    private readonly DataContext _context;

    public ToDoRepository(DataContext context)
    {
      _context = context;
    }
    public async Task<ToDo> AddAsync(ToDo todo)
    {
      var result = await _context.ToDos.AddAsync(todo);
      await _context.SaveChangesAsync();
      return result.Entity;
    }

    public async Task<List<ToDo>> GetAllAsync()
    {
      return await _context.ToDos.ToListAsync();
    }

    public async Task<ToDo?> GetByIdAsync(Guid id)
    {
      return await _context.ToDos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<ToDo>> GetCurrentToDosAsync()
    {
      return await _context.ToDos.Where(x => x.isDeleted == false).ToListAsync();
    }

    public async Task UpdateAsync(ToDo todo)
    {
      _context.ToDos.Update(todo);
      await _context.SaveChangesAsync();
    }
  }
}
