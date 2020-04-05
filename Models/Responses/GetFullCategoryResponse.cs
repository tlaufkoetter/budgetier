using System;
using System.Collections.Generic;

namespace BudgetierApi.Models.Responses
{
    public class GetFullCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Budget { get; set; }
        public GetCategoryResponse Parent {get;set;}
        public IEnumerable<GetMinCategoryResponse> Children {get;set;}
    }
}