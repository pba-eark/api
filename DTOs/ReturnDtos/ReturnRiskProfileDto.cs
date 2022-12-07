namespace pba_api.DTOs.ReturnDtos
{
    public class ReturnRiskProfileDto
    {
        public int Id { get; set; }
        public bool Global { get; set; }
        public bool Default { get; set; }
        public string ProfileName { get; set; }
        public int Percentage { get; set; }
    }
}
