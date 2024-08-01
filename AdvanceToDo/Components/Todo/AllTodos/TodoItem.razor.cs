using AdvanceToDo.Clients;
using AdvanceToDo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TodoModel = AdvanceToDo.Models.Todo;

namespace AdvanceToDo.Components.Todo.AllTodos
{
    public partial class TodoItem
    {
        [Parameter]
        public required TodoModel Todo {get;set;}

        [Inject]
        private TagsClient TagsClient {get;set;}=default!;

        [Inject]
        private TodoClient TodoClient {get;set;}= default!;

        public Tag[] activeTags = [];

        [Parameter]
        public EventCallback<MouseEventArgs> OnChange {get;set;}

       
        private async Task DeleteTodo(){
             TodoClient.DeleteTodo(Todo.Id);
             await OnChange.InvokeAsync();
        }

        private void ToggleCompleted(){
             TodoClient.ToggleCompleted(Todo.Id);
        }


        protected override void OnInitialized()
        {
             var allTags = TagsClient.GetTags();
             activeTags = allTags.Where(tag => Todo.TagsIds.Contains(tag.Id)).ToArray();
        }
    }
}