using pba_api.Models.EpicStatusModel;
using pba_api.Models.EstimateSheetModel;
using pba_api.Models.UserModel;
using System.Diagnostics.CodeAnalysis;

namespace pba_api.Models.EpicModel
{
    public class Epic
    {
        public int Id { get; set; }
        public string EpicName { get; set; }
        public string? Comment { get; set; }

        public int EstimateSheetId { get; set; }
        public EstimateSheet EstimateSheet { get; set; }

        public int EpicStatusId { get; set; }
        public EpicStatus EpicStatus { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public virtual ICollection<Models.TaskModel.Task> Tasks { get; set; }
    }
}
