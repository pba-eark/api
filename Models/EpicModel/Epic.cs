using pba_api.Models.EpicStatusModel;
using pba_api.Models.EstimateSheetModel;

namespace pba_api.Models.EpicModel
{
    public class Epic
    {
        public int Id { get; set; }
        public string EpicName { get; set; }

        public int EstimateSheetId { get; set; }
        public EstimateSheet EstimateSheet { get; set; }

        public int EpicStatusId { get; set; }
        public EpicStatus Epic { get; set; }
    }
}
