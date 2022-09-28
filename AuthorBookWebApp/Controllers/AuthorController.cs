using Microsoft.AspNetCore.Mvc;
using AuthorBookWebApp.Models;
using AuthorBookWebApp.BusinessLogic.Interfaces;

namespace AuthorBookWebApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorCrud<AuthorViewModel> _authorCrud;

        public AuthorController(IAuthorCrud<AuthorViewModel> crud)
        {
            _authorCrud = crud;
        }

        // GET: Author
        public IActionResult Index()
        {
            var authors = _authorCrud.GetAll();
            return View(authors);
        }

        // GET: Author/Details/5
        public IActionResult Details(int? id)
        {
            if (_authorCrud.GetById(id) == null)
            {
                return NotFound();
            }
            var author = _authorCrud.GetById(id);
            return View(author);

        }

        // GET: Author/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [AcceptVerbs("Post")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                AuthorViewModel author = new();

                author.Surname = Request.Form["Surname"];
                author.Name = Request.Form["Name"];
                author.SecondName = Request.Form["SecondName"];
                author.DateOfBirth = Convert.ToDateTime(Request.Form["DateOfBirth"]);                
                _authorCrud.Add(author);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Author/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _authorCrud.GetById(id) == null)
            {
                return NotFound();
            }

            var author = _authorCrud.GetById(id);            
            return View(author);
        }

        // POST: Author/Edit/5
        [AcceptVerbs("Post")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection formValues)
        {
            if (ModelState.IsValid)
            {
                var author = _authorCrud.GetById(id);

                author.Surname = Request.Form["Surname"];
                author.Name = Request.Form["Name"];
                author.SecondName = Request.Form["SecondName"];
                author.DateOfBirth = Convert.ToDateTime(Request.Form["DateOfBirth"]);
                _authorCrud.Update(id, author);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Author/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var res = _authorCrud.GetById(id);
            return View(res);
        }

        //// POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteA(int id)
        {
            _authorCrud.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
