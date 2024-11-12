namespace VismaSpcs.Recruitment.ChatService.Exceptions
{
    public static class Validate
    {
        public static void NotNull<T>(T entity, string text)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(text, $"{text} can't be null");
            }
        }
        
        public static void NotNullOrWhiteSpace(string? text, string name)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"{name} can't be null, empty or empty", name);
            }
        }
        
        public static void AlreadyExists<T>(T entity, string name)
        {
            if (entity != null)
            {
                throw new ArgumentException($"{name} already exists", name);
            }
        }
        
        public static void AlreadyExistsByBool(bool value, string text)
        {
            if (value)
            {
                throw new ArgumentException($"{text} already exists");
            }
        }
    }
}
