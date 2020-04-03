using System;
namespace BudgetierApi.Models.Responses
{
    public class GetCategoryBookingResponse
    {
        public class GetMinCategoryResponse
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Href { get; set; }
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Href { get; set; }
        public GetMinCategoryResponse Category { get; set; }
    }
}