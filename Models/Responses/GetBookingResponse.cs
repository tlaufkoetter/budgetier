using System;
namespace BudgetierApi.Models.Responses
{
    public class GetCategoryBookingResponse
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime TimeStamp { get; set; }
        public GetMinCategoryResponse Category { get; set; }
    }
}