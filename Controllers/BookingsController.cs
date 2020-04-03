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

namespace BudgetierApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BudgetierContext context;
        private readonly IMapper mapper;
        private GetCategoryBookingResponse WithHref(GetCategoryBookingResponse booking)
        {
            booking.Href = Url.Action(nameof(GetBookingById), new { id = booking.Id });
            booking.Category.Href = CategoriesController.GetHref(Url, booking.Category.Id);
            return booking;
        }
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
            response.Category = mapper.Map<GetCategoryBookingResponse.GetMinCategoryResponse>(booking.Category);

            return Ok(WithHref(response));
        }

        [HttpPost("")]
        public ActionResult<GetCategoryBookingResponse> PostBooking(PutBookingRequest booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookingEntity = mapper.Map<BookingEntity>(booking);
            context.Bookings.Add(bookingEntity);
            var year = booking.TimeStamp.Year;
            var month = booking.TimeStamp.Month;

            var categoryReport = context.CategoryReports
                .Where(r => r.CategoryId == booking.CategoryId
                    && r.Month == month
                    && r.Year == year).FirstOrDefault();
            var create = categoryReport == null;
            if (create)
            {
                categoryReport = new CategoryReportEntity() { CategoryId = booking.CategoryId, Year = year, Month = month };
            }
            categoryReport.Spent += (decimal)booking.Amount;
            categoryReport.Bookings.Add(bookingEntity);
            if (create)
                context.CategoryReports.Add(categoryReport);
            else
                context.Update(categoryReport);

            context.SaveChanges();

            context.Entry(bookingEntity).Reference(b => b.Category).Load();

            var bookingResponse = mapper.Map<GetCategoryBookingResponse>(bookingEntity);
            bookingResponse.Category = mapper.Map<GetCategoryBookingResponse.GetMinCategoryResponse>(bookingEntity.Category);


            return CreatedAtAction(nameof(GetBookingById), new {id = bookingEntity.Id}, WithHref(bookingResponse));
        }
    }
}