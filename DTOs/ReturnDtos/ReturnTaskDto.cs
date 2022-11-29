namespace pba_api.DTOs.ReturnDtos
{
    public class ReturnTaskDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string TaskName { get; set; }
        public double HourEstimate { get; set; }
        public string EstimateReasoning { get; set; }
        public bool OptOut { get; set; }
        public string TaskDescription { get; set; }

        public int EpicId { get; set; }
        public int RoleId { get; set; }
        public int RiskProfileId { get; set; }
    }
}
