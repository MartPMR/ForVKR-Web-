using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Domain.Entities;

namespace Library.Services
{
    /// <summary>
    /// Сервис по работе с каталогом , реализует логику работы с каталогом данных
    /// </summary>
    public class CatalogService
    {
        IRepository<CatalogOrder> rpCatalogOrder;
        IRepository<Book> rpBooks;
        IRepository<Author> rpAuthors;
        IRepository<Genre> rpGenres;

        /// <summary></summary>
        /// <param name="rpBooks">Репозиторий книг</param>
        /// <param name="rpCatalogOrder">Репозиторий заказов</param>
        public CatalogService(
            IRepository<Book> rpBooks,
            IRepository<CatalogOrder> rpCatalogOrder,
            IRepository<Author> rpAuthors,
            IRepository<Genre> rpGenres)
        {
            this.rpCatalogOrder = rpCatalogOrder;
            this.rpBooks = rpBooks;
            this.rpAuthors = rpAuthors;
            this.rpGenres = rpGenres;
        }


        #region Заказы

        /// <summary>Регистрация заказа</summary>
        /// <param name="UserName">Кто заказал</param>
        /// <param name="Book">Книга под заказ</param>
        public CatalogOrder CreateOrderBooks(string UserName, Cart Cart)
        {
            var newOrder = new CatalogOrder { UserName = UserName };
            newOrder.OrderItems = Cart.Lines.Select((cartItem) => new CatalogOrderItem { BookID = cartItem.book.ID_BOOK, Count = cartItem.Quantity, Order = newOrder }).ToList();
            rpCatalogOrder.Insert(newOrder);
            return newOrder;
        }

        #endregion

        #region Работа с книгами

        public Book SelectBook(int ID)
        {
            return rpBooks.Select(ID);
        }

        public IQueryable<Book> SelectBooks(string Genre = null, string BookFilter = null)
        {
            var query = rpBooks.Data;
            if (Genre != null) query = query.Where(book => book.genre_books.NAME_GENRE == Genre);
            if (BookFilter != null) query = query.Where(book => book.NAME_BOOK.IndexOf(BookFilter) >= 0 || book.author_books.A_NAME.IndexOf(BookFilter) >= 0);
            return query;
        }

        public void SaveBook(Book book)
        {
            if (book.ID_BOOK == 0) { rpBooks.Insert(book); return; }
            Book dbEntry = rpBooks.Select(book.ID_BOOK);
            if (dbEntry != null)
            {
                dbEntry.NAME_BOOK = book.NAME_BOOK;
                dbEntry.AUTHOR_ID = book.AUTHOR_ID;
                dbEntry.PUBLISHING_HOUSE_ID = book.PUBLISHING_HOUSE_ID;
                dbEntry.YEAR_PUB = book.YEAR_PUB;
                dbEntry.ISBN = book.ISBN;
                dbEntry.GENRE_ID = book.GENRE_ID;
                rpBooks.Update(dbEntry);
            }
        }

        public Book DeleteBook(int ID)
        {
            Book dbEntry = rpBooks.Select(ID);
            if (dbEntry != null) rpBooks.Delete(dbEntry);
            return dbEntry;
        }

        #endregion

        #region Авторы

        public Author SelectAuthor(int ID)
        {
            return rpAuthors.Select(ID);
        }

        public IQueryable<Author> SelectAuthors()
        {
            return rpAuthors.Data;
        }

        public void SaveAuthor(Author author)
        {
            if (author.ID_AUTHOR == 0) { rpAuthors.Insert(author); return; }
            Author dbEntry = rpAuthors.Select(author.ID_AUTHOR);
            if (dbEntry != null)
            {
                dbEntry.A_NAME = author.A_NAME;
                dbEntry.A_FIRST_NAME = author.A_FIRST_NAME;
                dbEntry.A_PATRONYMIC = author.A_PATRONYMIC;
                dbEntry.A_DATE_BIRTH = author.A_DATE_BIRTH;
                dbEntry.A_COUNTRY = author.A_COUNTRY;
                rpAuthors.Update(dbEntry);
            }

        }

        public Author DeleteAuthor(int ID)
        {
            Author dbEntry = rpAuthors.Select(ID);
            if (dbEntry != null) rpAuthors.Delete(dbEntry);
            return dbEntry;
        }

        #endregion

        //#region Публикации


        //public void SavePublishing(publishing_houses publishing_house)
        //{
        //    if (publishing_house.ID_PUBLISHING_HOUSE == 0) { rpHouses.Insert(publishing_house); return; }
        //    publishing_houses dbEntry = rpHouses.Select(publishing_house.ID_PUBLISHING_HOUSE);
        //    if (dbEntry != null)
        //    {
        //        dbEntry.NAME_P_H = publishing_house.NAME_P_H;
        //        dbEntry.ADRESS_P_H = publishing_house.ADRESS_P_H;
        //        dbEntry.PHONE = publishing_house.PHONE;
        //        rpHouses.Update(dbEntry);
        //    }
        //}

        //public publishing_houses DeletePublishing(int ID_PUBLISHING_HOUSE)
        //{
        //    publishing_houses dbEntry = rpHouses.Select(ID_PUBLISHING_HOUSE);
        //    if (dbEntry != null) rpHouses.Delete(dbEntry);
        //    return dbEntry;
        //}

        //#endregion

        #region Жанры


        public Genre SelectGenre(int ID)
        {
            return rpGenres.Select(ID);
        }

        public IQueryable<Genre> SelectGenres()
        {
            return rpGenres.Data;
        }

        public void SaveGenre(Genre genre)
        {
            if (genre.ID_GENRE == 0) { rpGenres.Insert(genre); return; }
            Genre dbEntry = rpGenres.Select(genre.ID_GENRE);
            if (dbEntry != null)
            {
                dbEntry.NAME_GENRE = genre.NAME_GENRE;
                rpGenres.Update(dbEntry);
            }
        }

        public Genre DeleteGenre(int ID)
        {
            Genre dbEntry = rpGenres.Select(ID);
            if (dbEntry != null) rpGenres.Delete(dbEntry);
            return dbEntry;
        }

        #endregion
    }
}
