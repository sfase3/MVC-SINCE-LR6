using Microsoft.AspNetCore.Mvc;
using mvcLR6.Models;

namespace mvcLR6
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/RegisterUser.cshtml");
        }

        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            if (user.Age > 16)
            {
                return View("~/Views/CountProducts.cshtml");
            }
            return View("~/Views/RegisterUser.cshtml");
        }

        public IActionResult OrderProducts(float quantity)
        {
            if ( (quantity > 0) && (quantity % 1 == 0) ) { 
            int IntQuantity= (int)quantity;
                List<Product> products = new List<Product>();

            for (int i = 1; i <= IntQuantity; i++)
            {
                products.Add(new Product { Id = i });
            }

            return View("~/Views/OrderProducts.cshtml", products);
            }
            return View("~/Views/CountProducts.cshtml");
        }

        [HttpPost]
        public IActionResult OrderComplete(List<Product> products)
        {
            return View("~/Views/OrderComplete.cshtml", products);
        }
    }
}
