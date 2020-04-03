using System;
using System.Collections.Generic;

namespace BudgetierApi.Data.Entities
{
    public class CategoryReportEntity
    {
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Spent { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
    }
}