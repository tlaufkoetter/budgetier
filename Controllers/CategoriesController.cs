using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BudgetierApi.Data;
using BudgetierApi.Data.Entities;
using BudgetierApi.Models;
using BudgetierApi.Models.Requests;
using BudgetierApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetierApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BudgetierContext context;
        private readonly IMapper mapper;

        public CategoriesController(BudgetierContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/category
        [HttpGet("")]
        public ActionResult<IEnumerable<GetFullCategoryResponse>> GetCategories(Guid? parentId)
        {
            var categoryEntities = context.Categories.Include(c => c.Children).Where(c => c.ParentId == parentId);

            var categories = categoryEntities.Select(mapper.Map<GetFullCategoryResponse>);
            return Ok(mapper.Map<IEnumerable<GetFullCategoryResponse>>(categories));
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public ActionResult<GetFullCategoryResponse> GetCategoryById(Guid id)
        {
            var category = context.Categories.Include(c => c.Children).Include(c => c.Parent).FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            return Ok(mapper.Map<GetFullCategoryResponse>(category));
        }

        // POST api/category
        [HttpPost("")]
        public ActionResult<GetFullCategoryResponse> Poststring(PutCategoryRequest categoryRequest)
        {
            var entity = mapper.Map<CategoryEntity>(categoryRequest);
            context.Categories.Add(entity);
            context.SaveChanges();
            var category = mapper.Map<GetFullCategoryResponse>(entity);
            return CreatedAtAction(nameof(GetCategoryById), new { id = entity.Id }, category);
        }
    }
}