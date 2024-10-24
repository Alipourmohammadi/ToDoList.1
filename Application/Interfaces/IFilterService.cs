
using ToDoList.Core.Entities;

namespace ToDoList.Applications.Interfaces
{
  public interface IFilterService
  {
    Task<List<ToDo>> FilterBy(bool done, DateTime time);
  }
}
