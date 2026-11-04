using System;
using System.Collections.Generic;
using System.Text;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Contracts
{
    /// <summary>
    /// Get all products
    /// </summary>
    /// <returns>List of products</returns>
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
    }
}
