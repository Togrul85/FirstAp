﻿namespace P326FirstApi.Dtos.ProductDtos
{
    public class ProductReturnDto
    {
        public string Name { get; set; }

        public double SalePrice { get; set; }

        public double CostPrice { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
