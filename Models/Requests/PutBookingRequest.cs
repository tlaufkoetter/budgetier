using System;
using System.ComponentModel.DataAnnotations;

namespace BudgetierApi.Models.Requests
{
    public class PutBookingRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public string SubCategoryName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "The field \"amount\" must be greater than {1}")]
        public double Amount { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
}