using pba_api.Models.EstimateSheetModel;
using pba_api.Models.RoleModel;

namespace pba_api.Models.EstimateSheetRoleModel
{
    public class EstimateSheetRole
    {
        public int EstimateSheetId { get; set; }
        public EstimateSheet EstimateSheet { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
