namespace pba_api.DTOs.CreateDtos
{
    public class CreateAdditionalExpenseDto
    {
        public string ExpenseName { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool Continuous { get; set; }
        public int EstimateSheetId { get; set; }
    }
}
