namespace pba_api.DTOs
{
    public class TaskDto
    {
        //public int Id { get; set; }
        public int ParentId { get; set; }
        public double HourEstimate { get; set; }
        public string EstimateReasoning { get; set; }
        public bool OptOut { get; set; }
        public string TaskDescription { get; set; }
    }
}
