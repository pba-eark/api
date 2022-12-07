namespace pba_api.DTOs.CreateDtos
{
    public class CreateRoleDto
    {
        public bool Global { get; set; }
        public bool Default { get; set; }
        public string RoleName { get; set; }
        public double HourlyWage { get; set; }
    }
}
