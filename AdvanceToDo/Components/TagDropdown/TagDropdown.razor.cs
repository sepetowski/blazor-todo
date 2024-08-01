using AdvanceToDo.Clients;
using AdvanceToDo.Models;
using Microsoft.AspNetCore.Components;

namespace AdvanceToDo.Components.TagDropdown
{
    public partial class TagDropdown
    {

        private CurrentMode currentMode = CurrentMode.Browsing;

        [Inject]
        private TagsClient TagsClient {get;set;}= default!;

        private FormTag? editingTag;

        [Parameter]
        public EventCallback<Tag> TagSelected {get;set;}

        [Parameter]
        public EventCallback<Tag> TagEdited {get; set;}

        
        [Parameter]
        public EventCallback<string> TagIdDeleted {get;set;}

        
        private async Task OnTagSelected(Tag tag){
            await TagSelected.InvokeAsync(tag);
        }
     
        private void OnChangeMode(CurrentMode mode)
        {
            currentMode = mode;
            if (mode == CurrentMode.Creating)
            {
                editingTag = new FormTag { Title = string.Empty };
            }
        }

        private void StartEditTag(CurrentMode mode, string? id)
        {
            OnChangeMode(mode);
            var tag = TagsClient.GetTags().FirstOrDefault(t => t.Id == id);

            if (tag is not null)
            {
                editingTag = new() { Id = tag.Id, Title = tag.Title };
            }
        }

        private async Task OnDelete(string id){
            TagsClient.DeleteTag(id);
            await TagIdDeleted.InvokeAsync(id);
        }

        private bool IsEdditing() => currentMode == CurrentMode.Editing;
       
        public enum CurrentMode
        {
            Browsing,
            Creating,
            Editing,
        }
    }
}