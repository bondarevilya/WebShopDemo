using System;
using System.Collections.Generic;
using System.Text;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Services
{
    /// <summary>
    /// Manipulates products data
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of products</returns>
        public Task<IEnumerable<ProductDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
