using MediatR;
using ProductService.Api.Commands;
using ProductService.Domain;

namespace ProductService.Commands
{
    public class ActivateProductHandler : IRequestHandler<ActivateProductCommand, ActivateProductResult>
    {
        private readonly IProductRepository _productRepository;

        public ActivateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ActivateProductResult> Handle(ActivateProductCommand request, CancellationToken cancellationToken)
        {
           var product = await _productRepository.FindById(request.ProductId);
            product.Activate();

            return new ActivateProductResult { ProductId = product.Id };

        }
    }
}
    