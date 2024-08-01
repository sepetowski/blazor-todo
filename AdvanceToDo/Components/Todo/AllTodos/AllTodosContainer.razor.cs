using AdvanceToDo.Clients;
using Microsoft.AspNetCore.Components;

namespace AdvanceToDo.Components.Todo.AllTodos
{
    public partial class AllTodosContainer
    {

        [Inject]
        private TodoClient TodoClient {get;set;}= default!;

        private void OnChange(){
            StateHasChanged();
        }
    }
}