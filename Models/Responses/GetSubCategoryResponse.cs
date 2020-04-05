using System;

namespace BudgetierApi.Models.Responses
{
    public class GetSubCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GetMinCategoryResponse Parent {get;set;}
    }
}