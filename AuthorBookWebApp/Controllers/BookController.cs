using AuthorBookWebApp.BusinessLogic.Implementation;
using AuthorBookWebApp.BusinessLogic.Interfaces;
using AuthorBookWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookCrud<BookViewModel> _bookCrud;
        private readonly IAuthorCrud<AuthorViewModel> _authorCrud;

        public BookController(IBookCrud<BookViewModel> crud1, IAuthorCrud<AuthorViewModel> crud2)
        {
            _bookCrud = crud1;
            _authorCrud = crud2;
        }

        // GET: Book
        public IActionResult Index()
        {
            var books = _bookCrud.GetAll();
            return View(books);
        }

        // GET: Book/Details/5
        public IActionResult Details(int? id)
        {
            if (_bookCrud.GetById(id) == null)
            {
                return NotFound();
            }
            var book = _bookCrud.GetById(id);
            return View(book);

        }

        // GET: Book/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewModel model = new ViewModel();
            model.Authors = _authorCrud.GetAllWithoutTracking();
            return View(model);
        }

        // POST: Book/Create
        [AcceptVerbs("Post")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                BookViewModel book = new();

                book.Title = Request.Form["Book.Title"];
                book.NumberOfPages = Convert.ToInt32(Request.Form["Book.NumberOfPages"]);
                book.Genre = Request.Form["Book.Genre"];
                book.authorViewModel = _authorCrud.GetByIdWithoutTracking(Convert.ToInt32(Request.Form["Book.authorViewModel"]));
                _bookCrud.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Book/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _bookCrud.GetById(id) == null)
            {
                return NotFound();
            }

            var book = _bookCrud.GetById(id);
            return View(book);
        }

        // POST: Book/Edit/5
        [AcceptVerbs("Post")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection formValues)
        {
            if (ModelState.IsValid)
            {
                var book = _bookCrud.GetById(id);

                book.Title = Request.Form["Title"];
                book.NumberOfPages = Convert.ToInt32(Request.Form["NumberOfPages"]);
                book.Genre = Request.Form["Genre"];
                _bookCrud.Update(id, book);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Book/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var res = _bookCrud.GetById(id);
            return View(res);
        }

        //// POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteA(int id)
        {
            _bookCrud.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
