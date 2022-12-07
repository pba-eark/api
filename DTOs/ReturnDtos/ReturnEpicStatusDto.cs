namespace pba_api.DTOs.ReturnDtos
{
    public class ReturnEpicStatusDto
    {
        public int Id { get; set; }
        public bool Global { get; set; }
        public bool Default { get; set; }
        public string EpicStatusName { get; set; }
    }
}
