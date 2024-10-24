using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Entities;

namespace Application.Repository
{
  public interface IToDoRepository
  {
    Task<ToDo?> GetByIdAsync(Guid id);
    Task<ToDo> AddAsync(ToDo todo);
    Task UpdateAsync(ToDo todo);
    Task<List<ToDo>> GetAllAsync();
    Task<List<ToDo>> GetCurrentToDosAsync();

  }
}
