using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BudgetierApi.Data;
using BudgetierApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using BudgetierApi.Models.Responses;
using BudgetierApi.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace BudgetierApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BudgetierContext context;
        private readonly IMapper mapper;
        public BookingsController(BudgetierContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/bookings/5
        [HttpGet("{id}")]
        public ActionResult<GetCategoryBookingResponse> GetBookingById(Guid id)
        {
            var booking = context.Bookings.Find(id);
            context.Entry(booking).Reference(b => b.Category).Load();
            if (booking == null)
                return NotFound();

            GetCategoryBookingResponse response = mapper.Map<GetCategoryBookingResponse>(booking);
            response.Category = mapper.Map<GetMinCategoryResponse>(booking.Category);

            return Ok(response);
        }

        private BookingEntity UpdateReports(PutBookingRequest booking)
        {
            var year = booking.TimeStamp.Year;
            var month = booking.TimeStamp.Month;

            var categoryId = booking.CategoryId;
            var subCategory = context.Categories.SingleOrDefault(c => c.ParentId == categoryId &&  EF.Functions.Like(c.Name, $"%{booking.SubCategoryName}%"));
            CategoryReportEntity subCategoryReport = null;
            if (subCategory == null)
            {
                subCategory = new CategoryEntity() { Name = booking.SubCategoryName, ParentId = booking.CategoryId };
            }
            else
            {
                subCategoryReport = context.CategoryReports.Find(subCategory.Id, year, month);
            }


            var createSubCategoryReport = subCategoryReport == null;
            if (createSubCategoryReport)
                subCategoryReport = new CategoryReportEntity { Category = subCategory, Year = year, Month = month};

            subCategoryReport.Spent += (decimal)booking.Amount;


            if (createSubCategoryReport)
                context.CategoryReports.Add(subCategoryReport);
            else
                context.Update(subCategoryReport);

            var categoryReport = context.CategoryReports
                .Find(categoryId, year, month);
            var create = categoryReport == null;
            if (create)
            {
                categoryReport = new CategoryReportEntity() { CategoryId = categoryId, Year = year, Month = month };
            }
            categoryReport.Spent += (decimal)booking.Amount;
            if (create)
                context.CategoryReports.Add(categoryReport);
            else
                context.Update(categoryReport);

            var bookingEntity = mapper.Map<BookingEntity>(booking);
            bookingEntity.CategoryId = subCategory.Id;
            context.Bookings.Add(bookingEntity);

            context.SaveChanges();

            return bookingEntity;
        }

        [HttpPost("")]
        public ActionResult<GetCategoryBookingResponse> PostBooking(PutBookingRequest booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (context.Categories.Find(booking.CategoryId) == null)
                return Conflict();

            var bookingEntity = UpdateReports(booking);

            context.Entry(bookingEntity).Reference(b => b.Category).Load();

            var bookingResponse = mapper.Map<GetCategoryBookingResponse>(bookingEntity);
            bookingResponse.Category = mapper.Map<GetMinCategoryResponse>(bookingEntity.Category);


            return CreatedAtAction(nameof(GetBookingById), new { id = bookingEntity.Id }, bookingResponse);
        }
    }
}