namespace DatabaseProject.Models
{
    public class Thesis
    {
        public int ThesisNo { get; set; }
        public string? ThesisName { get; set; }
        public string? Author { get; set; }
        public string? University { get; set; }
        public string? Institute { get; set; }
        public string? Language { get; set; }
        public string? Type { get; set; }
        public int Year { get; set; }
        public List<string>? Subjects { get; set; }
    }
}
