namespace pba_api.DTOs.ReturnDtos
{
    public class ReturnSheetStatusDto
    {
        public int Id { get; set; }
        public bool Global { get; set; }
        public bool Default { get; set; }
        public string SheetStatusName { get; set; }
    }
}
