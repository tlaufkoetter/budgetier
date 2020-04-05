using System.Collections.Generic;
using AutoMapper;
using BudgetierApi.Data.Entities;
using BudgetierApi.Models;
using BudgetierApi.Models.Requests;
using BudgetierApi.Models.Responses;

namespace BudgetierApi
{
    public class BudgetierProfile : Profile
    {
        public BudgetierProfile()
        {
            CreateMap<CategoryEntity, GetFullCategoryResponse>();
            CreateMap<CategoryEntity, GetMinCategoryResponse>();
            CreateMap<CategoryEntity, GetSubCategoryResponse>();
            CreateMap<CategoryEntity, GetCategoryResponse>();

            CreateMap<BookingEntity, GetCategoryBookingResponse>();
            CreateMap<BookingEntity, GetCategoryReportResponse.GetBookingResponse>();

            CreateMap<CategoryReportEntity, GetCategoryReportsResponse.GetMinCategoryReportRepsponse>();
            CreateMap<CategoryReportEntity, GetCategoryReportResponse>();

            CreateMap<PutBookingRequest, BookingEntity>();
            CreateMap<PutCategoryRequest, CategoryEntity>();
        }
    }
}