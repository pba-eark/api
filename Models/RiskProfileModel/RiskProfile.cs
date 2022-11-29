using pba_api.Models.EstimateSheetRiskProfileModel;

namespace pba_api.Models.RiskProfileModel
{
    public class RiskProfile
    {
        public int Id { get; set; }
        public bool Global { get; set; }
        public string ProfileName { get; set; }
        public int Percentage { get; set; }
        public bool Default { get; set; }

        public virtual ICollection<TaskModel.Task> Tasks { get; set; }
        public virtual ICollection<EstimateSheetRiskProfile> EstimateSheetRiskProfiles { get; set; }
    }
}
