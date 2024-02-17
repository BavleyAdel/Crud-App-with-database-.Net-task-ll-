using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_App.Data;
using Shop_App.Models;

namespace Shop_App.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Product> _Products = new List<Product>();
        private static List<Company> _company = new List<Company>();
        private static List<Category> _category = new List<Category>();
        private static List<Blog> _blogs = new List<Blog>();
        private readonly ApplicationDbContext _db;

        public DashBoardController(ApplicationDbContext db)
        {
            _company.Add(new Company { Id = 1, Name = "Nike" });
            _company.Add(new Company { Id = 2, Name = "Addidas" });
            _category.Add(new Category { Id = 1, Name = "Sports" });
            _category.Add(new Category { Id = 2, Name = "Life Style" });
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            //int id;
            //if (_Products.Count == 0)
            //{
            //    id = 1;
            //}
            //else
            //{
            //    id = _Products.Max(b => b.Id) + 1;
            //}
            //product.Id = id;
            //_Products.Add(product);
            _db.products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult ViewAllProducts()
        {
            var products = _db.products.Include(p => p.Company).ToList();
            return View(products);
        }

        public IActionResult DeleteProduct(int id)
        {
            //Product product = _Products.FirstOrDefault(x => x.Id == id);
            //_Products.Remove(product);

            Product? product = _db.products.SingleOrDefault(x => x.Id == id);
            _db.products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("ViewAllProducts");
        }

        public IActionResult EditProduct(int id)
        {
            //Product product = _Products.FirstOrDefault(x => x.Id == id);
            Product? product = _db.products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            //Product prd = _Products.FirstOrDefault(x => x.Id == product.Id);
            Product prd = _db.products.FirstOrDefault(x => x.Id == product.Id);

            //prd.Name = product.Name;
            //prd.Description = product.Description;
            //prd.Price = product.Price;
            //prd.Company.Name = product.Company.Name;
            //prd.Company.Id = product.Company.Id;
            prd.Name = product.Name;
            prd.Description = product.Description;
            prd.Price = product.Price;
            prd.CompanyId = product.CompanyId;
            _db.products.Update(product);
            _db.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            //int id;
            //if(_blogs.Count == 0)
            //{
            //    id = 1;
            //}
            //else
            //{
            //    id = _blogs.Max(b => b.Id) + 1;
            //}
            //blog.Id = id;
            //_blogs.Add(blog);
            _db.blogs.Add(blog);
            _db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult DisplayAllBlogs()
        {
            var blogs = _db.blogs.Include(p => p.category).ToList();
            return View(blogs);
        }


        public IActionResult DeleteBlog(int id)
        {
        //    Blog blog = _blogs.FirstOrDefault(x => x.Id == id);
        //    _blogs.Remove(blog);

            Blog? blog = _db.blogs.SingleOrDefault(x => x.Id == id);
            _db.blogs.Remove(blog);
            _db.SaveChanges();
            return RedirectToAction("DisplayAllBlogs");
        }

        public IActionResult EditBlog(int id)
        {
            //Blog blog = _blogs.FirstOrDefault(x=>x.Id == id);
            Blog? blog = _db.blogs.FirstOrDefault(x => x.Id == id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            //Blog blg = _blogs.FirstOrDefault(x=> x.Id == blog.Id);

            Blog blg = _db.blogs.FirstOrDefault(x => x.Id == blog.Id);

            blg.Title = blog.Title;
            blg.Description = blog.Description;
            blg.Date = blog.Date;
            blg.category.Name = blog.category.Name;
            blg.category.Id = blog.category.Id;

            _db.blogs.Update(blog);
            _db.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
