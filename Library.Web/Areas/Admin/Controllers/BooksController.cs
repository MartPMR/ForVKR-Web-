using System.Web.Mvc;
using System.Linq;

using Library.Web.Admin.Models;
using Library.Domain.Entities;
using Library.Services;

namespace Library.Web.Admin.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        public CatalogService srvCatalog { get; }

        public BooksController(CatalogService srvCatalog)
        {
            this.srvCatalog = srvCatalog;
        }

        public ViewResult Index()
        {
            return View(srvCatalog.SelectBooks());
        }

        public ViewResult Edit(int ID_BOOK)
        {
            return View(srvCatalog.SelectBook(ID_BOOK));
        }

        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                srvCatalog.SaveBook(book);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", book.NAME_BOOK);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ViewResult Create()
        {
            return View("Edit", new Book());
        }

        [HttpPost]
        public ActionResult Delete(int ID_BOOK)
        {
            Book deletedBook = srvCatalog.DeleteBook(ID_BOOK);
            if (deletedBook != null) TempData["message"] = $"Книга \"{deletedBook.NAME_BOOK}\" была удалена";
            return RedirectToAction("Index");
        }

    }
}

