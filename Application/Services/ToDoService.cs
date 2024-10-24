using Application.Repository;
using ToDoList.Applications.DTOs;
using ToDoList.Applications.Interfaces;
using ToDoList.Core.Entities;

namespace ToDoList.Applications.Services
{
  public class ToDoService : IToDoService
  {
    private readonly IToDoRepository _todoRepository;

    public ToDoService(IToDoRepository repository)
    {
      _todoRepository = repository;
    }
    public async Task<ToDo> AddNewToDo(ToDoDTO input)
    {
      var newTodo = new ToDo()
      {
        title = input.title
      };
      var newToDo = await _todoRepository.AddAsync(newTodo);

      return newToDo;
    }

    public async Task EditToDo(Guid Id, ToDoDTO input)
    {
      var todo = await _todoRepository.GetByIdAsync(Id);
      if (todo == null)
        throw new Exception("ToDo Not Found");
      todo.title = input.title;
      todo.title = input.title;
      await _todoRepository.UpdateAsync(todo);
    }

    public async Task<List<ToDo>> GetToDoList()
    {
      var todoList = await _todoRepository.GetAllAsync();
      return todoList.Where(x => x.isDeleted == false).ToList();
    }

    public async Task RemoveToDo(Guid Id)
    {
      var todo = await _todoRepository.GetByIdAsync(Id);
      if (todo == null)
        throw new Exception("ToDo Not Found");
      todo.isDeleted = true;
      await _todoRepository.UpdateAsync(todo);
    }
    public async Task setToDoStatus(Guid Id, bool isDone)
    {
      var todo = await _todoRepository.GetByIdAsync(Id);
      if (todo == null)
        throw new Exception("ToDo Not Found");
      todo.isDone = isDone;
      await _todoRepository.UpdateAsync(todo);
    }
  }
}
