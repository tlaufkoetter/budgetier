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

        private GetCategoryReportsResponse.GetMinCategoryReportRepsponse WithRef(GetCategoryReportsResponse.GetMinCategoryReportRepsponse report, int year, int month)
        {
            report.Href = Url.Action(nameof(GetCategoryById), new { id = report.Category.Id, year = year, month = month });
            return report;
        }

        private GetCategoryReportsResponse WithRef(GetCategoryReportsResponse report, int year, int month)
        {
            report.Href = Url.Action(nameof(GetCategoryReports), new { year = year, month = month });
            report.Reports = report.Reports.Select(c => WithRef(c, year, month));
            return report;
        }

        private GetCategoryReportResponse WithRef(GetCategoryReportResponse report, int year, int month)
        {
            report.Href = Url.Action(nameof(GetCategoryById), new { id = report.Category.Id, year = year, month = month });
            report.Category.Href = CategoriesController.GetHref(Url, report.Category.Id);
            return report;
        }

        // GET api/categoryreports
        [HttpGet("")]
        public ActionResult<GetCategoryReportsResponse> GetCategoryReports(int year = 0, [Range(1, 12)]int month = 0)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categories = context.Categories;
            var reportEntities = new List<CategoryReportEntity>();
            var now = DateTime.Now;

            if (month < 1 || month > 12)
                month = now.Month;

            if (year == 0)
                year = now.Year;
            foreach (var category in categories)
            {
                var report = context.CategoryReports.Where(r => r.CategoryId == category.Id && r.Month == month && r.Year == year).FirstOrDefault();
                if (report == null)
                {
                    report = new CategoryReportEntity() { Category = category, CategoryId = category.Id, Month = month, Year = year, Spent = 0M };
                }
                reportEntities.Add(report);
            }
            var reports = reportEntities.Select(r => mapper.Map<GetCategoryReportsResponse.GetMinCategoryReportRepsponse>(r));

            var response = new GetCategoryReportsResponse() { Month = month, Year = year, Reports = reports};

            return Ok(WithRef(response, year, month));
        }

        // GET api/categoryreports/5
        [HttpGet("{id}")]
        public ActionResult<GetCategoryReportResponse> GetCategoryById(Guid id, int year = 0, [Range(1,12)]int month = 0)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var now = DateTime.Now;

            if (month < 1 || month > 12)
                month = now.Month;

            if (year == 0)
                year = now.Year;

            var report = context.CategoryReports.Where(r => r.CategoryId == id && r.Month == month && r.Year == year).FirstOrDefault();
            if (report == null)
            {
                var category = context.Categories.Find(id);
                if (category == null)
                    return NotFound();

                report = new CategoryReportEntity()
                {
                    Month = month,
                    Year = year,
                    Category = category
                };
            }
            else
            {
                context.Entry(report).Collection(r => r.Bookings).Load();
                context.Entry(report).Reference(r => r.Category).Load();
            }

            var reportResponse = mapper.Map<GetCategoryReportResponse>(report);
            reportResponse.Bookings = report.Bookings.Select(mapper.Map<GetCategoryReportResponse.GetBookingResponse>);
            return Ok(WithRef(reportResponse, year, month));
        }
    }
}