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
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            string dataPath = config.GetValue<string>("DataFiles:Products")
                ?? throw new InvalidOperationException("Не задана настройка DataFiles:Products");

            string fullPath = System.IO.Path.Combine(AppContext.BaseDirectory, dataPath);

            string json = await System.IO.File.ReadAllTextAsync(fullPath);

            return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ProductDto>>(json)!;
        }
    }
}
