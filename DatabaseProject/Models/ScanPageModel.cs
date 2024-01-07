namespace DatabaseProject.Models
{
    public class ScanPageModel
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public List<Thesis> ThesisList { get; set; } = new List<Thesis>();
    }
}
