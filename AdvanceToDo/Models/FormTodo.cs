using System.ComponentModel.DataAnnotations;

namespace AdvanceToDo.Models
{
    public class FormTodo
    {

        [Required]
        [MaxLength(50,ErrorMessage ="Title is too long")]
        [MinLength(3,ErrorMessage ="Title is too short")]
        public required string Title {get; set;}
        [Required]
        [MaxLength(2500,ErrorMessage ="Description is too long")]
        [MinLength(3,ErrorMessage ="Description is too short")]
        public required string Description {get; set;}
        [Required]
        public PiorityLevel PiorityLevel{get;set;}= PiorityLevel.Normal;
        public string[] TagsIds {get;set;} = [];
    }
}
