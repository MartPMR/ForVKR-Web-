using System.Web.Mvc;
using System.Linq;

using Library.Domain.Entities;
using Library.Services;

namespace Library.Web.Admin.Controllers
{
    [Authorize]
    public class GenresController : Controller
    {
        public CatalogService srvCatalog { get; }
        public GenresController(CatalogService srvCatalog)
        {
            this.srvCatalog = srvCatalog;
        }

        public ViewResult Index()
        {
            return View(srvCatalog.SelectGenres());
        }

        public ViewResult Edit(int ID_GENRE)
        {
            return View(srvCatalog.SelectGenre(ID_GENRE));
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                srvCatalog.SaveGenre(genre);
                TempData["message"] = $"Изменения в игре \"{genre.NAME_GENRE}\" были сохранены";
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        public ViewResult Create()
        {
            return View("Edit", new Genre());
        }

        [HttpPost]
        public ActionResult DeleteGenre(int ID_GENRE)
        {
            Genre deletedGenre = srvCatalog.DeleteGenre(ID_GENRE);
            if (deletedGenre != null) TempData["message"] = $"Книга \"{deletedGenre.NAME_GENRE}\" была удалена";
            return RedirectToAction("Index");
        }

    }
}