using pba_api.Models.EstimateSheetModel;
using pba_api.Models.RiskProfileModel;
using pba_api.Models.UserModel;

namespace pba_api.Models.EstimateSheetUserModel
{
    public class EstimateSheetUser
    {
        public int Id { get; set; }
        public int EstimateSheetId { get; set; }
        public EstimateSheet EstimateSheet { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Type { get; set; }
    }
}
