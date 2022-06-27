using Dot_Net_Core_Practice.Data;
using Dot_Net_Core_Practice.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dot_Net_Core_Practice.Controllers
{
    public class BooksController1 : Controller
    {
        private readonly ApplicationDbContext _db;

        public BooksController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Books> objBooksList = _db.Books;
            return View(objBooksList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Books obj)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Add Book Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Edit(int? BookID)
        {
            if(BookID == null || BookID == 0)
            {
                return NotFound();
            }
            var BooksFromDb = _db.Books.Find(BookID);
            //var BooksFromDbFirst = _db.Books.FirstOrDefault(x=>x.BookID == BookID);
            //var BooksFromDbSingle = _db.Books.SingleOrDefault(x => x.BookID == BookID);

            if(BooksFromDb == null)
            {
                return NotFound();
            }
            return View(BooksFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Books obj)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Update Book Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? BookID)
        {
            if (BookID == null || BookID == 0)
            {
                return NotFound();
            }
            var BooksFromDb = _db.Books.Find(BookID);
            //var BooksFromDbFirst = _db.Books.FirstOrDefault(x=>x.BookID == BookID);
            //var BooksFromDbSingle = _db.Books.SingleOrDefault(x => x.BookID == BookID);

            if (BooksFromDb == null)
            {
                return NotFound();
            }
            return View(BooksFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? BookID)
        {
            var obj = _db.Books.Find(BookID);
            if (obj == null )
            {
                return NotFound();
            }

            _db.Books.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Delete Book Successfully";
            return RedirectToAction("Index");
        }
    }
}
