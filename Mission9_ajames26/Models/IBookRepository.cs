using System.Linq;

namespace Mission9_ajames26.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
