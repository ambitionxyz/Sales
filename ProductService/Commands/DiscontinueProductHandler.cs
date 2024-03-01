using MediatR;
using ProductService.Api.Commands;
using ProductService.Domain;

namespace ProductService.Commands
{
    public class DiscontinueProductHandler : IRequestHandler<DiscontinueProductCommand, DiscontinueProductResult>
    {
        private readonly IProductRepository _productRepository;

        public DiscontinueProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DiscontinueProductResult> Handle(DiscontinueProductCommand request, CancellationToken cancellationToken)
        {
          var product = await _productRepository.FindById(request.ProductId);
            product.Discontinue();

            return new DiscontinueProductResult { ProductId  = product.Id };

        }
    }
}
