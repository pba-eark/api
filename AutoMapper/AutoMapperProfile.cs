using AutoMapper;
using pba_api.DTOs;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.CustomerModel;
using pba_api.Models.EstimateSheetModel;
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

        }
    }
}
