using System;
using System.Collections.Generic;

namespace BudgetierApi.Data.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Budget { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
        public Guid? ParentId { get; set; }
        public CategoryEntity Parent { get; set; }
        public ICollection<CategoryEntity> Children { get; set; } = new List<CategoryEntity>();
    }
}