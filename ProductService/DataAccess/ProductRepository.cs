using Microsoft.EntityFrameworkCore;
using ProductService.Domain;

namespace ProductService.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));

        }

        public async Task<Product> Add(Product product)
        {
          await _productDbContext.Products.AddAsync(product);
            return product;
        }

        public async Task<List<Product>> FindAllActive()
        {
           return await _productDbContext
                .Products
                .Include(c => c.Covers)
                .Include("Questions.Choices")
                .Where(p => p.Status == ProductStatus.Active)
                .ToListAsync();
        }

        public async Task<Product> FindById(Guid id)
        {
            return await _productDbContext
                .Products
                .Include(c => c.Covers)
                .Include("Questions.Choises")
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> FindOne(string productCode)
        {
            return await _productDbContext
             .Products
             .Include(c => c.Covers)
             .Include("Questions.Choices")
             .FirstOrDefaultAsync(p => p.Code.Equals(productCode, StringComparison.InvariantCultureIgnoreCase)); ;
        }
    }
}
