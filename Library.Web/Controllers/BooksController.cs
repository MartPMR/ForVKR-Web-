using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Library.Domain.Entities;
using Library.Services;
using Library.Web.Models;

namespace Library.Web.Controllers
{
    public class BooksController : Controller
    {
        public int pageSize = 4;
        private CatalogService srvCatalog;

        public BooksController(CatalogService srvCatalog)
        {
            this.srvCatalog = srvCatalog;
        }

        public ViewResult List(string genre, int page = 1, string bookFilter = null)
        {
            var bookList = srvCatalog.SelectBooks(genre, bookFilter);

            BooksListViewModel model = new BooksListViewModel
            {
                bookList = bookList.OrderBy(book => book.ID_BOOK).Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                CurrentGenre = genre,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = bookList.Count()
                }
            };

            return View(model);
        }
    }
}