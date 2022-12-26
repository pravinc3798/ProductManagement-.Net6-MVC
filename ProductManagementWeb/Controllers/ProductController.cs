using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;


namespace ProductManagementWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBL productBL;

        public ProductController(IProductBL productBL)
        {
            this.productBL = productBL;
        }

        public IActionResult Index(int page = 0)
        {
            IEnumerable<ViewProductModel> products = productBL.ViewProduct();

            const int PageSize = 10;
            var count = products.Count();

            var data = products.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            ViewBag.Page = page;

            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]ProductModel inputModel)
        {
            if (DateTime.Compare(inputModel.ExpiryDate, DateTime.Now) < 0)
            {
                ModelState.AddModelError("Expiry", "Expiry date must be a future date.");
                return View(inputModel);
            }

            var result = productBL.AddProduct(inputModel);

            if (!result)
            {
                ModelState.AddModelError("Code", "Code is already registered !!");
                return View(inputModel);
            }

            return RedirectToAction("Index");
        }


    }
}
