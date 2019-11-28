using System.Web.Mvc;
using System.Linq;

using Library.Domain.Entities;
using Library.Services;

namespace Library.Web.Admin.Controllers
{
    public class AuthorsController : Controller
    {
        public CatalogService srvCatalog { get; }

        public AuthorsController(CatalogService srvCatalog)
        {
            this.srvCatalog = srvCatalog;
        }

        public ViewResult Index()
        {
            return View(srvCatalog.SelectAuthors());
        }

        public ViewResult Edit(int ID_AUTHOR)
        {
            return View(srvCatalog.SelectAuthor(ID_AUTHOR));
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                srvCatalog.SaveAuthor(author);
                TempData["message"] = string.Format("Изменения в авторе книги \"{0}\" были сохранены", author.A_FIRST_NAME);
                return RedirectToAction("Index");
            }

            // Что-то не так со значениями данных
            return View(author);
        }

        public ViewResult Create()
        {
            return View("Edit", new Author());
        }

        [HttpPost]
        public ActionResult DeleteAuthor(int ID_AUTHOR)
        {
            Author deletedAuthor = srvCatalog.DeleteAuthor(ID_AUTHOR);
            if (deletedAuthor != null) TempData["message"] = $"Автор \"{deletedAuthor.A_FIRST_NAME}\" была удалена";
            return RedirectToAction("Index");
        }
    }
}