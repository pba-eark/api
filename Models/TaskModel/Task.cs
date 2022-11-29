using pba_api.Models.EpicModel;
using pba_api.Models.EstimateSheetModel;
using pba_api.Models.RiskProfileModel;
using pba_api.Models.RoleModel;

namespace pba_api.Models.TaskModel
{
    public class Task
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string TaskName { get; set; }
        public double HourEstimate { get; set; }
        public string? EstimateReasoning { get; set; }
        public bool OptOut { get; set; }
        public string? TaskDescription { get; set; }

        public int EpicId { get; set; }
        public Epic Epic { get; set; }

        public int? RoleId { get; set; }
        public Role? Role { get; set; }

        public int RiskProfileId { get; set; }
        public RiskProfile RiskProfile { get; set; }
    }
}
