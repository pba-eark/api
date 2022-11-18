namespace pba_api.DTOs
{
    public class AdditionalExpenseDto
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; }
        public double Price { get; set; }
        public bool Continuous { get; set; }
        public int EstimateSheetId { get; set; }
    }
}
