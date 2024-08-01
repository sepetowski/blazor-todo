using AdvanceToDo.Models;
using AdvanceToDo.Shared;

namespace AdvanceToDo.Clients
{
    public class TagsClient(TodoClient todoClient)
    {
        private readonly List<Tag> Tags = new();
        public Tag[] GetTags()=> Tags.ToArray();
        public ResponseInfo AddNewTag(string title){
            Tag newTag= new(){Title=title,Id=GenerateRandomId.GenerateID()};

            var tag = Tags.Find(tag => string.Equals(tag.Title, newTag.Title, StringComparison.OrdinalIgnoreCase));

            if(tag is null) {
                Tags.Add(newTag);
                return new ResponseInfo();
            }
            return new ResponseInfo(){Error=true,Message="This tag title already exists."};
        }

        public ResponseInfo DeleteTag(string id){
            var tag= Tags.Find(tag=>tag.Id==id);

            if(tag is not null){
                Tags.Remove(tag);
                var todos= todoClient.GetTodos();

                foreach (var todo in todos){
                    if (todo.TagsIds.Contains(id)){
                        var tagsList = todo.TagsIds.ToList();
                        tagsList.Remove(id);
                        todo.TagsIds = [.. tagsList];
                     }
                    }
                
                return new ResponseInfo();
            }
               return new ResponseInfo(){Error=true,Message="Tag not found."};
        }

       public ResponseInfo EditTagTitle(Tag tag){
    
            var existingTag = Tags.Find(t => t.Id == tag.Id);

            if (existingTag is not null){
            var checkIfNameExists = Tags.Find(t => string.Equals(t.Title, tag.Title, StringComparison.OrdinalIgnoreCase));
            
            if (checkIfNameExists is null){
            existingTag.Title = tag.Title;
            return new ResponseInfo();
            }
            else
            return new ResponseInfo { Error = true, Message = "This tag title already exists." };
            
            }
            
            return new ResponseInfo { Error = true, Message = "Tag not found." };
        }
    }
}
