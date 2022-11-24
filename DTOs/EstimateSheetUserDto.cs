using pba_api.Models.EstimateSheetModel;
using pba_api.Models.UserModel;

namespace pba_api.DTOs
{
    public class EstimateSheetUserDto
    {
        public int EstimateSheetId { get; set; }
        public int UserId { get; set; }
    }
}
