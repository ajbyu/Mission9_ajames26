using System.Linq;

namespace Mission9_ajames26.Models
{
    public class BookRepository : IBookRepository
    {
        private BookstoreContext _context { get; set; }

        public BookRepository(BookstoreContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;        

    }
}
