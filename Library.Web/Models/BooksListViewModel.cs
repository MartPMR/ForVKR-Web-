using System.Collections.Generic;
using Library.Domain.Entities;
using Library.Domain.Entities;

namespace Library.Web.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> bookList { get; set; }
        public IEnumerable<Genre> genreList { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}