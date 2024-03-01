using MediatR;
using ProductService.Api.Queries;
using ProductService.Api.Queries.Dtos;
using ProductService.DataAccess;
using ProductService.Domain;
using ProductService.Queries.Mappers;

namespace ProductService.Queries
{
    public class FindAllProductsHandler : IRequestHandler<FindAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public FindAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        }
        public async Task<IEnumerable<ProductDto>> Handle(FindAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.FindAllActive();

            return result.Select(p => new ProductDto
            {
                Code = p.Code,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                MaxNumberOfInsured = p.MaxNumberOfInsured,
                Icon = p.ProductIcon,
                Questions = p.Questions != null ? ProductMapper.ToQuestionDtoList(p.Questions) : null,
                Covers = p.Covers.Any() ? ProductMapper.ToCoverDtoList(p.Covers) : null
            }).ToList();
        }
    }
}
