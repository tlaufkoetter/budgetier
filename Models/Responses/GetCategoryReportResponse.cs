using System;
using System.Collections.Generic;

namespace BudgetierApi.Models.Responses
{
    public class GetCategoryReportResponse
    {
        public class GetBookingResponse
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public decimal Amount { get; set; }
            public DateTime TimeStamp { get; set; }
            public GetSubCategoryResponse Category { get; set; }
        }

        public GetFullCategoryResponse Category { get; set; }
        public decimal Spent { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public IEnumerable<GetBookingResponse> Bookings { get; set; }
    }
}