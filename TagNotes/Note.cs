namespace TagNotes
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;  // Ensure non-nullable initialization
        public string Tags { get; set; } = string.Empty;     // Ensure non-nullable initialization
    }
}
