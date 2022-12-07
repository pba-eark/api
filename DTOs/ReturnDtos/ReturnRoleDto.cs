namespace pba_api.DTOs.ReturnDtos
{
    public class ReturnRoleDto
    {
        public int Id { get; set; }
        public bool Global { get; set; }
        public bool Default { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public double HourlyWage { get; set; }
    }
}
