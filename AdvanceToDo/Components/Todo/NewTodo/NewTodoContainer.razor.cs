using AdvanceToDo.Clients;
using AdvanceToDo.Models;
using Microsoft.AspNetCore.Components;

namespace AdvanceToDo.Components.Todo.NewTodo
{
    public partial class NewTodoContainer
    {
        [SupplyParameterFromForm(FormName ="NewTodo")]
        private FormTodo? Model {get;set;}

        [Inject]
        private TodoClient TodoClient {get;set;}= default!;

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

            TodoClient.AddTodo(Model);

            OnClear();
            
            }
        }

        private void OnClear(){
           Model= new FormTodo(){Title=string.Empty,Description=string.Empty};
           SelectedTags= [];
        }

        protected override void OnInitialized()
        {
            OnClear();
        }

    }
}