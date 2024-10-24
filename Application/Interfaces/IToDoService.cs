using ToDoList.Applications.DTOs;
using ToDoList.Core.Entities;

namespace ToDoList.Applications.Interfaces
{
  public interface IToDoService
  {
    Task<ToDo> AddNewToDo(ToDoDTO input);
    Task RemoveToDo(Guid Id);
    Task EditToDo(Guid Id, ToDoDTO input);
    Task<List<ToDo>> GetToDoList();
    Task setToDoStatus(Guid Id, bool isDone);

  }
}
