using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.DTO
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public BrandDto Brand { get; set; }
        public GenderDto Gender { get; set; }
        public decimal  Price { get; set; }
        public string Description { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public IEnumerable<ImageDto> Images { get; set; } = new List<ImageDto>();
        public IEnumerable<ProductSizeDto> Sizes { get; set; } = new List<ProductSizeDto>();
    }
    public class UpdateProductDto : BaseDto
    {
        public string Name { get; set; }

        public int? BrandId { get; set; }
        public int? GenderId { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> Categories { get; set; } = new List<int>();
    }

    public class CreateProductDto
    {
        public string ImageFileName;
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int GenderId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> Categories { get; set; } = new List<int>();
    }
}
