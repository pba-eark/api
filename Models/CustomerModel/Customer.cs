using pba_api.Models.EstimateSheetModel;
using System.Text.Json.Serialization;

namespace pba_api.Models.CustomerModel
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        [JsonIgnore]
        public virtual ICollection<EstimateSheet> EstimateSheets { get; set; }
    }
}
