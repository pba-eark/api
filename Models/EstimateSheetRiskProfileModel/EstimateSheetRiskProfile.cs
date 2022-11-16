using pba_api.Models.EstimateSheetModel;
using pba_api.Models.RiskProfileModel;
using pba_api.Models.SheetStatusModel;

namespace pba_api.Models.EstimateSheetRiskProfileModel
{
    public class EstimateSheetRiskProfile
    {
        public int EstimateSheetId { get; set; }
        public EstimateSheet EstimateSheet { get; set; }
        public int RiskProfileId { get; set; }
        public RiskProfile RiskProfile { get; set; }
    }
}
