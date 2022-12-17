namespace pba_api.DTOs.CreateDtos
{
    public class CreateSheetStatusDto
    {
        public bool Global { get; set; }
        public bool Default { get; set; }
        public string SheetStatusName { get; set; }
        public string? SheetStatusColor { get; set; }
    }
}
