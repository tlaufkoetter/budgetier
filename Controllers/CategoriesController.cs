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

namespace BudgetierApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BudgetierContext context;
        private readonly IMapper mapper;

        private GetCategoryResponse WithHref(GetCategoryResponse category) 
        {
            category.Href = GetHref(Url, category.Id);
            return category;
        }


        public static String GetHref(IUrlHelper url, Guid id)
        {
            return url.Action(nameof(GetCategoryById), nameof(CategoriesController).Replace("Controller", ""), new { id = id });
        }

        public CategoriesController(BudgetierContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET api/category
        [HttpGet("")]
        public ActionResult<IEnumerable<GetCategoryResponse>> GetCategories()
        {
            return Ok(mapper.Map<IEnumerable<GetCategoryResponse>>(context.Categories).Select(WithHref));
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public ActionResult<GetCategoryResponse> GetCategoryById(Guid id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
                return NotFound();

            return Ok(WithHref(mapper.Map<GetCategoryResponse>(category)));
        }

        // POST api/category
        [HttpPost("")]
        public ActionResult<GetCategoryResponse> Poststring(PutCategoryRequest categoryRequest)
        {
            var entity = mapper.Map<CategoryEntity>(categoryRequest);
            context.Categories.Add(entity);
            context.SaveChanges();
            var category = mapper.Map<GetCategoryResponse>(entity);
            return CreatedAtAction(nameof(GetCategoryById), new {id = entity.Id}, WithHref(category));
        }
    }
}