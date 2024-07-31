using System.ComponentModel.DataAnnotations;

namespace AdvanceToDo.Models
{
    public class FormTag
    {
        public string? Id {get; set;}= string.Empty;

        [Required]
        [MinLength(3,ErrorMessage ="Title is too short")]
        [MaxLength(20,ErrorMessage ="Title is too long")]
        public required string Title {get; set;}= string.Empty;
    }
}
