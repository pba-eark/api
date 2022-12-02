namespace pba_api.DTOs.CreateDtos
{
    public class CreateEpicDto
    {
        public string EpicName { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public int EstimateSheetId { get; set; }
        public int EpicStatusId { get; set; }
    }
}
