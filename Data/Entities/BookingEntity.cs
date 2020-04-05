using System;
using BudgetierApi.Models;

namespace BudgetierApi.Data.Entities
{
    public class BookingEntity
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}