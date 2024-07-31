using AdvanceToDo.Clients;
using AdvanceToDo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AdvanceToDo.Components.TagDropdown
{
    public partial class TagItem
    {
        [Parameter]
        public EventCallback<MouseEventArgs> OnStartEdit {get; set;}
        
        [Parameter]
        public EventCallback<MouseEventArgs> OnDelete {get; set;}

        [Parameter]
        public required Tag Tag {get; set;}
        
    }
}