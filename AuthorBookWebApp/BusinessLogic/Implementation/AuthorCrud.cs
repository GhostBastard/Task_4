using AuthorBookWebApp.BusinessLogic.Interfaces;
using AuthorBookWebApp.DbData;
using AuthorBookWebApp.DbData.DbModel;
using AuthorBookWebApp.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookWebApp.BusinessLogic.Implementation
{
    public class AuthorCrud : IAuthorCrud<AuthorViewModel>
    {
        private readonly AbDbContext _context;
        private readonly IMapper _mapper;

        public AuthorCrud(AbDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Add(AuthorViewModel model)
        {
            var author = _mapper.Map<AuthorDbModel>(model);
            _context.Add(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Authors.Where(b => b.Id == id).FirstOrDefault();
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        public AuthorViewModel? GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                try
                {
                    var dbAuthor = _context.Authors.Where(a => a.Id == id).FirstOrDefault();
                    dbAuthor.Books = _context.Books.Where(x => x.authorDbModel.Id == dbAuthor.Id).ToList();
                    return _mapper.Map<AuthorViewModel>(dbAuthor);
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
            }
        }

        public AuthorViewModel? GetByIdWithoutTracking(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                try
                {
                    var dbAuthor = _context.Authors.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    return _mapper.Map<AuthorViewModel>(dbAuthor);
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
            }
        }

        public List<AuthorViewModel> GetAll()
        {
            var dbAuthor = _context.Authors.ToList();
            List<AuthorViewModel> res = new();
            foreach (var item in dbAuthor)
            {
                res.Add(_mapper.Map<AuthorViewModel>(item));
            }
            return res;
        }
        public List<AuthorViewModel> GetAllWithoutTracking()
        {
            var dbAuthor = _context.Authors.ToList();
            List<AuthorViewModel> res = new();
            foreach (var item in dbAuthor)
            {
                res.Add(_mapper.Map<AuthorViewModel>(item));
            }
            return res;
        }

        public void Update(int id, AuthorViewModel model)
        {
            AuthorDbModel editedAuthor = _context.Authors.Where(a => a.Id == id).FirstOrDefault();

            if (editedAuthor != null)
            {
                var author = _mapper.Map<AuthorDbModel>(model);
                editedAuthor.Name = author.Name;
                editedAuthor.Surname = author.Surname;
                editedAuthor.SecondName = author.SecondName;
                editedAuthor.DateOfBirth = author.DateOfBirth;
                _context.SaveChanges();
            }
        }
    }
}
