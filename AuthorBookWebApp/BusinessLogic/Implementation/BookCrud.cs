using AuthorBookWebApp.BusinessLogic.Interfaces;
using AuthorBookWebApp.DbData.DbModel;
using AuthorBookWebApp.DbData;
using AuthorBookWebApp.Models;
using AutoMapper;

namespace AuthorBookWebApp.BusinessLogic.Implementation
{
    public class BookCrud : IBookCrud<BookViewModel>
    {
        private readonly AbDbContext _context;
        private readonly IMapper _mapper;

        public BookCrud(AbDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Add(BookViewModel model)
        {
            BookDbModel author = new BookDbModel();
            author.Title = model.Title;
            author.NumberOfPages = model.NumberOfPages;
            author.Genre = model.Genre;
            author.authorDbModel = _mapper.Map<AuthorDbModel>(model.authorViewModel);
            _context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Set<BookDbModel>().Update(author);
            _context.Add(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Books.Where(b => b.Id == id).FirstOrDefault();
            if (author != null)
            {
                _context.Books.Remove(author);
                _context.SaveChanges();
            }
        }

        public BookViewModel? GetById(int? id)
        {
            var dbAuthor = _context.Books.Where(a => a.Id == id).FirstOrDefault();
            return _mapper.Map<BookViewModel>(dbAuthor);
        }

        public List<BookViewModel> GetAll()
        {
            var dbBook = _context.Books.ToList();
            List<BookViewModel> res = new();
            foreach (var item in dbBook)
            {
                res.Add(_mapper.Map<BookViewModel>(item));
            }
            return res;
        }

        public void Update(int id, BookViewModel model)
        {
            BookDbModel editedBook = _context.Books.Where(a => a.Id == id).FirstOrDefault();


            if (editedBook != null)
            {
                var book = _mapper.Map<BookDbModel>(model);
                editedBook.Title = book.Title;
                editedBook.NumberOfPages = book.NumberOfPages;
                editedBook.Genre = book.Genre;
                _context.SaveChanges();
            }
        }
    }
}
