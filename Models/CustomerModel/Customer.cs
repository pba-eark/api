using pba_api.Models.EstimateSheetModel;

namespace pba_api.Models.CustomerModel
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public virtual ICollection<EstimateSheet> EstimateSheets { get; set; }
    }
}
