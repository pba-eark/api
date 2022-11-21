namespace pba_api.DTOs.CreateDtos
{
    public class CreateRiskProfileDto
    {
        public bool Global { get; set; }
        public string ProfileName { get; set; } = string.Empty;
        public int Percentage { get; set; }
    }
}
