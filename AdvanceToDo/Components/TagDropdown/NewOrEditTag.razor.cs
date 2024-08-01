using AdvanceToDo.Clients;
using AdvanceToDo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AdvanceToDo.Components.TagDropdown
{
    public partial class NewOrEditTag
    {

        [SupplyParameterFromForm(FormName ="EditOrNewTag")]
        public FormTag? Model {get;set;}
     
        [Parameter]
        public bool Editing {get;set;}= false;

        [Parameter]
        public FormTag? Tag {get;set;}

        [Parameter]
        public EventCallback<MouseEventArgs> OnCancel {get; set;}

        [Parameter]
        public EventCallback<Tag> TagEdited {get; set;}

        [Inject]
        private TagsClient TagsClient {get;set;}=default!;

        private string? errorMsg;
      
        private async Task SubmitAsync()
        {
            if(Tag is not null){
           
                if(Editing){
                    Tag newTag= new(){Id=Tag.Id!,Title=Tag.Title};
                    var res =TagsClient.EditTagTitle(newTag);

                    if(res.Message is not null){
                        errorMsg=res.Message;
                    }

                    if(res.Error==false){
                        await OnCancel.InvokeAsync();
                        await TagEdited.InvokeAsync(newTag);
                    }
                }else{
                    var res = TagsClient.AddNewTag(Tag.Title);

                    if(res.Message is not null){
                        errorMsg=res.Message;
                    }

                    if(res.Error==false)
                        await OnCancel.InvokeAsync();    
                }
            }
        }

        protected override void OnInitialized()
        {

            Model = Tag;
            errorMsg=null;
        }
    }
}