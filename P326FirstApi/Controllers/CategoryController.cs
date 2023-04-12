using P326FirstApi.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P326FirstApi.Dtos.ProductDtos;
using P326FirstApi.Dtos.CategoryDtos;

namespace P326FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var category = _appDbContext.Categories
                .Where(c => !c.IsDeleted)
                .FirstOrDefault(c=>c.Id==id);
            if (category == null) return NotFound();
            CategoryReturnDto categoryReturnDto = new();
            categoryReturnDto.Name = category.Name;
            categoryReturnDto.Desc = category.Desc;
            categoryReturnDto.CreatedDate = category.CreatedDate;
            categoryReturnDto.UpdateDate = category.UpdateDate;

            return Ok(category);
        }

        [HttpGet]
        public IActionResult GetAll(int page)
        {
            var query = _appDbContext.Categories
                 .Where(p => !p.IsDeleted);

            CategoryListDto categoryListDto = new();

            categoryListDto.TotalCount = query.Count();
            categoryListDto.CurrentPage = page;
            categoryListDto.Items = query.Skip((page - 1) * 2)
                .Take(2)
                .Select(c => new CategoryListItemDto
                {
                    Name = c.Name,
                   
                    CreatedDate = c.CreatedDate,
                    UpdateDate = c.UpdateDate,

                }).ToList();
            List<CategoryListItemDto> listItemDtos = new();

            productListDto.Items = listItemDtos;
            return StatusCode(200, productListDto);

            //return Ok(new {Code=1001,products});
        }

    }
}
