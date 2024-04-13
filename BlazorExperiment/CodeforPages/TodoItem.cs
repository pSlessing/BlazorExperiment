namespace BlazorExperiment
{
    public class TodoItem
    {
        public string? Title { get; set; }
        public bool IsDone { get; set; }
        public string? Description { get; set; }
        public Priority? Priority { get; set; }
    }

    public enum Priority
    {
        High = 3, Medium = 2, Low = 1
    }
}
