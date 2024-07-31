namespace AdvanceToDo.Shared
{
    public static class GenerateRandomId
    {
        public static string GenerateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
