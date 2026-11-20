using System;
using System.Collections.Generic;
using System.Text;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;
using Microsoft.Extensions.Configuration;
using WebShopDemo.Core.Data.Common;
using Microsoft.EntityFrameworkCore;
using WebShopDemo.Core.Data.Models;

namespace WebShopDemo.Core.Services
{
    /// <summary>
    /// Manipulates products data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IRepository repo;
        private readonly IConfiguration config;

        //private readonly ApplicationDbContext context;
        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config">Applification configuration</param>
        public ProductService(IConfiguration _config,
            IRepository _repo
            //IApplicationDbContext _context
            )
        {
            this.config = _config;
            this.repo = _repo;
            //this.context = _context;
        }

        public async Task Add(ProductDto productDto)
        {
            var product = new Data.Models.Product()
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };
            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            //await context.AddAsync(product);
            //await context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await repo.AllReadonly<Product>().Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToListAsync();
        }
    }
}
