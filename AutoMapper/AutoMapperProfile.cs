using AutoMapper;
using pba_api.DTOs;
using pba_api.DTOs.Composites;
using pba_api.DTOs.CreateDtos;
using pba_api.DTOs.ReturnDtos;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.CustomerModel;
using pba_api.Models.EpicModel;
using pba_api.Models.EpicStatusModel;
using pba_api.Models.EstimateSheetModel;
using pba_api.Models.EstimateSheetRiskProfileModel;
using pba_api.Models.EstimateSheetUserModel;
using pba_api.Models.RiskProfileModel;
using pba_api.Models.RoleModel;
using pba_api.Models.SheetStatusModel;
using pba_api.Models.UserModel;

namespace pba_api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EstimateSheet, CreateEstimateSheetDto>();
            CreateMap<CreateEstimateSheetDto, EstimateSheet>();
            CreateMap<EstimateSheet, ReturnEstimateSheetDto>();

            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReturnUserDto>();
            CreateMap<User, UserLoginDTO>();

            CreateMap<Customer, CreateCustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, ReturnCustomerDto>();

            CreateMap<AdditionalExpense, CreateAdditionalExpenseDto>();
            CreateMap<CreateAdditionalExpenseDto, AdditionalExpense>();
            CreateMap<AdditionalExpense, ReturnAdditionalExpenseDto>();

            CreateMap<Epic, CreateEpicDto>();
            CreateMap<CreateEpicDto, Epic>();
            CreateMap<Epic, ReturnEpicDto>();

            CreateMap<EpicStatus, CreateEpicStatusDto>();
            CreateMap<CreateEpicStatusDto, EpicStatus>();
            CreateMap<EpicStatus, ReturnEpicStatusDto>();

            CreateMap<Models.TaskModel.Task, CreateTaskDto>();
            CreateMap<CreateTaskDto, Models.TaskModel.Task>();
            CreateMap<Models.TaskModel.Task, ReturnTaskDto>();

            CreateMap<RiskProfile, CreateRiskProfileDto>();
            CreateMap<CreateRiskProfileDto, RiskProfile>();
            CreateMap<RiskProfile, ReturnRiskProfileDto>();

            CreateMap<SheetStatus, CreateSheetStatusDto>();
            CreateMap<CreateSheetStatusDto, SheetStatus>();
            CreateMap<SheetStatus, ReturnSheetStatusDto>();

            CreateMap<Role, CreateRoleDto>();
            CreateMap<CreateRoleDto, Role>();
            CreateMap<Role, ReturnRoleDto>();

            CreateMap<EstimateSheetUser, EstimateSheetUserDto>();
            CreateMap<EstimateSheetUserDto, EstimateSheetUser>();

            CreateMap<EstimateSheetRiskProfile, EstimateSheetRiskProfileDto>();
            CreateMap<EstimateSheetRiskProfileDto, EstimateSheetRiskProfile>();
        }
    }
}
