using P326FirstApi.Models;

namespace P326FirstApi.Dtos.ProductDtos
{
    public class ProductListDto
    {
public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public List<ProductListItemDto> Items { get; set; }
    }
}
