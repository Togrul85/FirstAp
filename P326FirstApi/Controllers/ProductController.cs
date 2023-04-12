using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P326FirstApi.Data.DAL;
using P326FirstApi.Dtos.ProductDtos;
using P326FirstApi.Models;
using System.Collections.Generic;

namespace P326FirstApi.Controllers
{
  
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetAll(int page,string search)
        {
            var products = _appDbContext.Products
                .Where(p=>!p.IsDeleted)
                .Skip(page-1)*8)
                .Take(2)
                .ToList();
            ProductListDto productListDto = new();

            productListDto.TotalCount= products.Count;
            productListDto.Items = products.Select(p => new ProductListItemDto
            {

                Name = p.Name,
                CostPrice = p.CostPrice,
                SalePrice = p.SalePrice,
                CreatedDate = p.CreatedDate,
                UpdateDate = p.UpdateDate,

            }).ToList();
            List<ProductListItemDto> listItemDtos = new();
           
            productListDto.Items= listItemDtos;
            return StatusCode(200, productListDto);

            //return Ok(new {Code=1001,products});
        }
        [Route("{id}")]
        [HttpGet]

        public IActionResult GetOne(int id)
        { 
       Product product = _appDbContext.Products
                .Where(p=>!p.IsDeleted)
                .FirstOrDefault(p => p.Id == id);

        if (product == null) return StatusCode(StatusCodes.Status404NotFound);
            ProductReturnDto productReturnDto = new()
            {
                Name = product.Name,
                SalePrice = product.SalePrice,
                CostPrice = product.CostPrice,
                CreatedDate = product.CreatedDate,
                UpdateDate = product.UpdateDate,

            };
            return Ok(productReturnDto); 
        }

        [HttpPost]

        public IActionResult AddProduct(ProductCreateDto productCreateDto) 
        {
            Product newProduct = new()
            {
                Name = productCreateDto.Name,
                SalePrice= productCreateDto.SalePrice,
                CostPrice= productCreateDto.CostPrice,
                IsActive= productCreateDto.IsActive,
                IsDeleted= productCreateDto.IsDeleted,
            };
        _appDbContext.Products.Add(newProduct);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, newProduct);

        }
        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(int id) 
        {

            var product = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
           
        }

        [HttpPut("{id}")]

        public IActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {

            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            existProduct.Name = productUpdateDto.Name;
            existProduct.SalePrice = productUpdateDto.SalePrice;
            existProduct.CostPrice = productUpdateDto.CostPrice;
            existProduct.IsActive = productUpdateDto.IsActive;
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);

        }

        [HttpPatch]
        public IActionResult ChangeStatus(int id ,bool IsActive)
        {
            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();  
            existProduct.IsActive = IsActive;
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
        }

    }
}


