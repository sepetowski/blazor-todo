using AdvanceToDo.Clients;
using AdvanceToDo.Models;
using Microsoft.AspNetCore.Components;

namespace AdvanceToDo.Components.Todo.EditTodo
{
    public partial class EditTodoForm
    {


        [Parameter]
        public string? Id {get;set;}

        [Inject]
        public TodoClient TodoClient {get;set;}=default!;

        [Inject]
        public TagsClient TagsClient {get;set;}=default!;

        [Inject]
        public NavigationManager NavigationManager {get;set;}=default!;

        [SupplyParameterFromForm(FormName ="EditTodo")]
        public FormTodo? Model {get;set;}

        private List<Tag> SelectedTags=[];


         private void OnTagSelected(Tag tag){
            var selctedTag=SelectedTags.FirstOrDefault((newTag)=>newTag.Id==tag.Id);

            if(selctedTag is null)
            SelectedTags.Add(tag);
        }

          private void OnRemoveTag(string tagId){
            var selctedTag=SelectedTags.FirstOrDefault((newTag)=>newTag.Id==tagId);

            if(selctedTag is not null)
            SelectedTags.Remove(selctedTag);
        }

        private void OnTagEdited(Tag editedTag){
            var index=SelectedTags.FindIndex((tag)=>tag.Id==editedTag.Id);
            SelectedTags[index]= new Tag(){Id=editedTag.Id,Title=editedTag.Title};
        }

        private void OnDeletedTagFromList(string id){
            var deleted=SelectedTags.FirstOrDefault((tag)=>tag.Id==id);
                
                
            if(deleted is not null)
            SelectedTags.Remove(deleted);
        }

         private void HandleSubmit(){
            if(Model is not null){

            List<string> ids = [];
            
            foreach(var tag in SelectedTags)
                ids.Add(tag.Id);

            Model.TagsIds= [.. ids];

            if(Id is not null){
            TodoClient.EditTodo(Model,Id);
            NavigationManager.NavigateTo("/todos");
            }
        
            }
        }

        protected override void OnParametersSet()
        {

            if(Id is not null){
            var todo=TodoClient.GetTodoById(Id);
            var allTags = TagsClient.GetTags();
            if(todo is not null){
                SelectedTags = allTags.Where(tag => todo.TagsIds.Contains(tag.Id)).ToList();
                Model= new(){Title=todo.Title,Description=todo.Description,TagsIds=todo.TagsIds,PiorityLevel=todo.PiorityLevel};
            }
            }
            
        }

    }
}