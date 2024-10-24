using Application.Repository;
using ToDoList.Applications.Interfaces;
using ToDoList.Core.Entities;

namespace ToDoList.Applications.Services
{
  public class FilterService : IFilterService
  {
    private readonly IToDoRepository _todoRepository;

    public FilterService(IToDoRepository repository)
    {
      _todoRepository = repository;
    }

    public async Task<List<ToDo>> FilterBy(bool done, DateTime time)
    {
      var result = await _todoRepository.GetAllAsync();
      return result.Where(x => x.isDone == done).Where(x => x.dateCreated > time).Where(x => x.isDeleted == false).ToList();
    }

  }
}
