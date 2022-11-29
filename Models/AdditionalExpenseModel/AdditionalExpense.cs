using pba_api.Models.EstimateSheetModel;

namespace pba_api.Models.AdditionalExpensesModel
{
    public class AdditionalExpense
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; }
        public double Price { get; set; }
        public bool Continuous { get; set; }

        public int? EstimateSheetId { get; set; }
        public EstimateSheet? EstimateSheet { get; set; }
    }
}
