using Microsoft.AspNetCore.Mvc;

namespace WebShopDemo.API.Controllers
{
    /// <summary>
    /// Web shop products controller
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// Lists all products
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
