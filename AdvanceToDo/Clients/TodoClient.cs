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

        public void DeleteTodo(string id){
            var todo= Todos.Find(t=>t.Id==id);

            if(todo is not null)
                Todos.Remove(todo);
        }

        public void ToggleCompleted(string id){
             var todo= Todos.Find(t=>t.Id==id);

            if(todo is not null){

                if(todo.CompleteDate is null)
                todo.CompleteDate= DateTime.UtcNow;
                else
                 todo.CompleteDate= null;
            }
        }
    }
}
