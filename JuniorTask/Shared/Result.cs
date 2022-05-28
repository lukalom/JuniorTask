namespace JuniorTask.Shared
{
    public class Result<T>
    {
        public T? Content { get; set; }
        public List<string>? Errors { get; set; }
        public bool IsSuccess => Errors == null;
    }
}
