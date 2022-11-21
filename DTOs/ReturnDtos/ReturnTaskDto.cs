namespace pba_api.DTOs.ReturnDtos
{
    public class ReturnTaskDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public double HourEstimate { get; set; }
        public string EstimateReasoning { get; set; } = string.Empty;
        public bool OptOut { get; set; }
        public string TaskDescription { get; set; } = string.Empty;
    }
}
