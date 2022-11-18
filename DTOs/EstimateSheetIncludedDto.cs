using pba_api.Models.CustomerModel;
using pba_api.Models.SheetStatusModel;
using pba_api.Models.UserModel;

namespace pba_api.DTOs
{
    public class EstimateSheetIncludedDto
    {
        public EstimateSheetDto sheet { get; set; }
        public User? user { get; set; }
        public Customer? customer { get; set; }
        public SheetStatus? status { get; set; }
    }
}
