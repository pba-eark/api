using AutoMapper;
using pba_api.DTOs;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.CustomerModel;
using pba_api.Models.EpicModel;
using pba_api.Models.EpicStatusModel;
using pba_api.Models.EstimateSheetModel;
using pba_api.Models.RiskProfileModel;
using pba_api.Models.UserModel;

namespace pba_api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EstimateSheet, EstimateSheetDto>();
            CreateMap<EstimateSheetDto, EstimateSheet>();

            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<AdditionalExpense, AdditionalExpenseDto>();
            CreateMap<AdditionalExpenseDto, AdditionalExpense>();

            CreateMap<Epic, EpicDto>();
            CreateMap<EpicDto, Epic>();

            CreateMap<EpicStatus, EpicStatusDto>();
            CreateMap<EpicStatusDto, EpicStatus>();

            CreateMap<Task, TaskDto>();
            CreateMap<TaskDto, Task>();

            CreateMap<RiskProfile, RiskProfileDto>();
            CreateMap<RiskProfileDto, RiskProfile>();
        }
    }
}
