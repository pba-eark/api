namespace pba_api.DTOs.ReturnDtos
{
    public class ReturnRiskProfileDto
    {
        public int Id { get; set; }
        public bool Global { get; set; }
        public string ProfileName { get; set; } = string.Empty;
        public int Percentage { get; set; }
    }
}
