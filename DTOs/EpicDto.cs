using pba_api.Models.EstimateSheetModel;

namespace pba_api.DTOs
{
    public class EpicDto
    {
        public string EpicName { get; set; }
        public int EstimateSheetId { get; set; }
        public int EpicStatusId { get; set; }
    }
}
