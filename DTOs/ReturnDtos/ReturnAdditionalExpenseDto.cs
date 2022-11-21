namespace pba_api.DTOs.ReturnDtos
{
    public class ReturnAdditionalExpenseDto
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool Continuous { get; set; }
        public int EstimateSheetId { get; set; }
    }
}
