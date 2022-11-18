using pba_api.Models.EstimateSheetModel;

namespace pba_api.Models.SheetStatusModel
{
    public class SheetStatus
    {
        public int Id { get; set; }
        public string SheetStatusName { get; set; }

        public virtual ICollection<EstimateSheet> EstimateSheets { get; set; }
    }
}
