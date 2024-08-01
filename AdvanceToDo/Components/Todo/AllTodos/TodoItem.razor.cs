using AdvanceToDo.Clients;
using AdvanceToDo.Models;
using Microsoft.AspNetCore.Components;
using TodoModel = AdvanceToDo.Models.Todo;

namespace AdvanceToDo.Components.Todo.AllTodos
{
    public partial class TodoItem
    {
        [Parameter]
        public required TodoModel Todo {get;set;}

        [Inject]
        private TagsClient TagsClient {get;set;}=default!;

        public Tag[] activeTags = [];


        protected override void OnInitialized()
        {
             var allTags = TagsClient.GetTags();
             activeTags = allTags.Where(tag => Todo.TagsIds.Contains(tag.Id)).ToArray();
        }
    }
}