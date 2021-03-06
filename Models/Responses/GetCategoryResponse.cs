using System;
using System.Collections.Generic;

namespace BudgetierApi.Models.Responses
{
    public class GetCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Budget { get; set; }
    }
}