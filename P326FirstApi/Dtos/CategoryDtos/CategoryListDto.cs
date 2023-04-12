namespace P326FirstApi.Dtos.CategoryDtos
{
    public class CategoryListDto<T>
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public List<CategoryListItemDto> Items { get; set; }
    }
}
