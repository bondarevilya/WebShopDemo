using System;
using System.Collections.Generic;
using System.Text;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;
using Microsoft.Extensions.Configuration;

namespace WebShopDemo.Core.Services
{
    /// <summary>
    /// Manipulates products data
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IConfiguration config;
        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config">Applification configuration</param>
        public ProductService(IConfiguration _config)
        {
            this.config = _config;
        }
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of products</returns>
        public Task<IEnumerable<ProductDto>> GetAll()
        {
            string dataPath = config.GetValue<string>("DataFiles:Products");

            return Task.FromResult<IEnumerable<ProductDto>>(System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ProductDto>>(System.IO.File.ReadAllText(dataPath))!);
        }
    }
}
