using pba_api.Models.EstimateSheetModel;
using System.Text.Json.Serialization;

namespace pba_api.Models.SheetStatusModel
{
    public class SheetStatus
    {
        public int Id { get; set; }
        public string SheetStatusName { get; set; }
        [JsonIgnore]
        public virtual ICollection<EstimateSheet> EstimateSheets { get; set; }
    }
}
