using AspSneakers.Application.UseCases.DTO;
using Microsoft.AspNetCore.Http;

namespace AspSneakers.Api.DTO
{
    public class UploadFileDto : CreateProductDto
    {
        public IFormFile Image { get; set; }
    }
}
