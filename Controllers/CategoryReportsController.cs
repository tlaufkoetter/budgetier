using Microsoft.CSharp.RuntimeBinder;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BudgetierApi.Data;
using BudgetierApi.Data.Entities;
using BudgetierApi.Models;
using BudgetierApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BudgetierApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryReportsController : ControllerBase
    {
        private readonly BudgetierContext context;
        private readonly IMapper mapper;

        public CategoryReportsController(BudgetierContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/categoryreports
        [HttpGet("")]
        public ActionResult<GetCategoryReportsResponse> GetCategoryReports(int? year, [Range(1, 12)]int? month)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categories = context.Categories.Where(c => !c.ParentId.HasValue);
            var reportEntities = new List<CategoryReportEntity>();
            var now = DateTime.Now;

            if (!month.HasValue)
                month = now.Month;

            if (!year.HasValue)
                year = now.Year;
            foreach (var category in categories)
            {
                var report = context.CategoryReports.Include(r => r.Category).FirstOrDefault(r => r.CategoryId == category.Id && r.Month == month.Value && r.Year == year.Value);
                if (report == null)
                {
                    report = new CategoryReportEntity() { Category = category, CategoryId = category.Id, Month = month.Value, Year = year.Value, Spent = 0M };
                }
                reportEntities.Add(report);
            }
            var reports = reportEntities.Select(r => mapper.Map<GetCategoryReportsResponse.GetMinCategoryReportRepsponse>(r));

            var response = new GetCategoryReportsResponse() { Month = month.Value, Year = year.Value, Reports = reports};

            return Ok(response);
        }

        // GET api/categoryreports/5
        [HttpGet("{id}")]
        public ActionResult<GetCategoryReportResponse> GetCategoryById(Guid id, int? year, [Range(1,12)]int? month)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var now = DateTime.Now;

            if (!month.HasValue)
                month = now.Month;

            if (!year.HasValue)
                year = now.Year;

            IEnumerable<BookingEntity> bookings;
            var report = context.CategoryReports.Include(r => r.Category)
                .ThenInclude(c => c.Children).Include(r => r.Category)
                .ThenInclude(c => c.Parent)
                .FirstOrDefault(r => r.CategoryId == id && r.Month == month.Value && r.Year == year.Value);
            if (report == null)
            {
                var category = context.Categories.Find(id);
                if (category == null)
                    return NotFound();

                report = new CategoryReportEntity()
                {
                    Month = month.Value,
                    Year = year.Value,
                    Category = category
                };
                bookings = new List<BookingEntity>();
            }
            else
            {
                bookings = context.Bookings.Include(b => b.Category).ThenInclude(c => c.Parent).Where(b => b.CategoryId == report.CategoryId || report.Category.Children.Select(c => c.Id).Any(c => c == b.CategoryId));
            }

            var reportResponse = mapper.Map<GetCategoryReportResponse>(report);
            reportResponse.Bookings = bookings.Select(mapper.Map<GetCategoryReportResponse.GetBookingResponse>);
            reportResponse.Category.Children = reportResponse.Category.Children.Select(mapper.Map<GetMinCategoryResponse>);
            return Ok(reportResponse);
        }
    }
}