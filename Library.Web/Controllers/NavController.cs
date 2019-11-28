using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Library.Services;

namespace Library.Web.Controllers
{
    public class NavController : Controller
    {
        private CatalogService srvCatalog;

        public NavController(CatalogService srvCatalog)
        {
            this.srvCatalog = srvCatalog;
        }

        public PartialViewResult Menu(string genre = null)
        {
            ViewBag.SelectedNameGenre = genre;
            IEnumerable<string> genres = srvCatalog.SelectBooks().Select(book => book.genre_books.NAME_GENRE).Distinct().OrderBy(x => x).ToList();
            return PartialView("FlexMenu", genres);
        }

    }
}