namespace pba_api.Models
{
    public class EstimateSheet
    {
        public int Id { get; set; }
        public string SheetName { get; set; }
        public int JiraBoardId { get; set;}
        public string WorkbookLink { get; set; }
        public string JiraLink { get; set; }
        public string WireframeLink { get; set; }
    }
}
