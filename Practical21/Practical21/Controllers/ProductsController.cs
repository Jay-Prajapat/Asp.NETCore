using Microsoft.AspNetCore.Mvc;

namespace Practical21.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("list")]
        public IDictionary<int, string> Get()
        {
            IDictionary<int, string> list = new Dictionary<int, string>();
            list.Add(1, "IPhone");
            list.Add(2, "Laptop");
            list.Add(3, "Samsung TV");
            return list;
        }
    }
}
