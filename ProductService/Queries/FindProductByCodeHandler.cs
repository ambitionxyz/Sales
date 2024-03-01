using MediatR;
using ProductService.Api.Queries.Dtos;
using ProductService.Api.Queries;
using ProductService.Domain;
using ProductService.Queries.Mappers;

namespace ProductService.Queries
{
    public class FindProductByCodeHandler : IRequestHandler<FindProductByCodeQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public FindProductByCodeHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<ProductDto> Handle(FindProductByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.FindOne(request.ProductCode);

            return result != null
                ? new ProductDto
                {
                    Code = result.Code,
                    Name = result.Name,
                    Description = result.Description,
                    Image = result.Image,
                    MaxNumberOfInsured = result.MaxNumberOfInsured,
                    Icon = result.ProductIcon,
                    Questions = result.Questions != null ? ProductMapper.ToQuestionDtoList(result.Questions) : null,
                    Covers = result.Covers != null ? ProductMapper.ToCoverDtoList(result.Covers) : null
                }
                : null;
        }
    }
}
