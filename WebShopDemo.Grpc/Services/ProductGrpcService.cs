using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using WebShopDemo.Core.Contracts;

namespace WebShopDemo.Grpc.Services
{
    public class ProductGrpcService : Product.ProductBase
    {
        private readonly IProductService productService;

        public ProductGrpcService(IProductService productService)
        {
            this.productService = productService;
        }

        public override async Task<ProductList> GetAll(Empty request, ServerCallContext context)
        {
            ProductList result = new ProductList();
            var products = await productService.GetAll();

            result.Items.AddRange(products.Select(p => new ProductItem()
            {
                Name = p.Name,
                Id = p.ID.ToString(),
                Price = (double)p.Price,
                Quantity = p.Quantity
            }));

            return result;
        }
    }
}
