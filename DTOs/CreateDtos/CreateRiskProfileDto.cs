namespace pba_api.DTOs.CreateDtos
{
    public class CreateRiskProfileDto
    {
        public bool Global { get; set; }
        public bool Default { get; set; }
        public string ProfileName { get; set; }
        public int Percentage { get; set; }
    }
}
