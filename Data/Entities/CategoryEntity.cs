using System;
using System.Collections.Generic;
using BudgetierApi.Models;

namespace BudgetierApi.Data.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
    }
}