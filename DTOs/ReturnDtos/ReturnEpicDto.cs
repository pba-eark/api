namespace pba_api.DTOs.ReturnDtos
{
    public class ReturnEpicDto
    {
        public int Id { get; set; }
        public string EpicName { get; set; } = string.Empty;
        public string Comment { get; set; }
        public int EstimateSheetId { get; set; }
        public int EpicStatusId { get; set; }
    }
}
