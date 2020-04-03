using System.ComponentModel.DataAnnotations;

namespace BudgetierApi.Models.Requests
{
    public class PutCategoryRequest
    {
        [Required]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Field \"budget\" must be greater than {1}")]
        public double? Budget { get; set; }
    }
}