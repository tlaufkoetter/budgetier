using System;
using System.Collections.Generic;

namespace BudgetierApi.Models.Responses
{
    public class GetCategoryReportsResponse
    {
        public class GetMinCategoryReportRepsponse
        {
            public GetCategoryResponse Category { get; set; }
            public decimal Spent { get; set; }
            public string Href { get; set; }
        }

        public int Month { get; set; }
        public int Year { get; set; }
        public IEnumerable<GetMinCategoryReportRepsponse> Reports { get; set; }
        public string Href { get; set; }

    }
}