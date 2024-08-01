namespace AdvanceToDo.Models
{
    public class Todo
    {
        public required string Id {get; set;}
        public required string Title {get; set;}
        public required string Description {get; set;}
        public DateTime CreationAt {get;set;} = DateTime.UtcNow;
        public DateTime? CompleteDate {get;set;}
        public PiorityLevel PiorityLevel{get;set;}= PiorityLevel.Normal;
        public string[] TagsIds {get;set;} = [];

    }

    public enum PiorityLevel{
        Low,
        Normal,
        Medium,
        High
    }
}
