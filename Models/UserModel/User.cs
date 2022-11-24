using pba_api.Models.EstimateSheetModel;
using pba_api.Models.EstimateSheetUserModel;

namespace pba_api.Models.UserModel
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public virtual ICollection<EstimateSheetUser> EstimateSheetUsers { get; set; }
    }
}
