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
            CreateMap<CategoryEntity, GetCategoryBookingResponse.GetMinCategoryResponse>();
            CreateMap<BookingEntity, GetCategoryBookingResponse>();
            CreateMap<CategoryEntity, GetCategoryResponse>();
            CreateMap<CategoryReportEntity, GetCategoryReportsResponse.GetMinCategoryReportRepsponse>();
            CreateMap<BookingEntity, GetCategoryReportResponse.GetBookingResponse>();
            CreateMap<CategoryReportEntity, GetCategoryReportResponse>();

            CreateMap<PutBookingRequest, BookingEntity>();
            CreateMap<PutCategoryRequest, CategoryEntity>();
        }
    }
}