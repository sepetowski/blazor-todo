using AdvanceToDo.Models;
using AdvanceToDo.Shared;

namespace AdvanceToDo.Clients
{
    public class TodoClient
    {
        private List<Todo> Todos= new();

        public Todo[] GetTodos()=> [..Todos];

        public void AddTodo(FormTodo todo){
            Todo newTodo= new(){
                Id=GenerateRandomId.GenerateID(),
                Title=todo.Title,
                Description=todo.Description,
                PiorityLevel=todo.PiorityLevel,
                TagsIds=todo.TagsIds
            };

            Todos.Add(newTodo);
        }
    }
}
