using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class DbInit : DropCreateDatabaseIfModelChanges<CatalogDbContext>
    {
        protected override void Seed(CatalogDbContext context)
        {
            var publish = context.Publishings.Add(new Domain.Entities.Publishing { ADRESS_P_H = "Адрес", NAME_P_H = "Луч", PHONE = "333-44-33" });
            var author1 = context.Authors.Add(new Domain.Entities.Author { A_COUNTRY = "Р.Ф.", A_DATE_BIRTH = DateTime.Parse("09.09.1828"), A_FIRST_NAME = "Толстой", A_NAME = "Лев", A_PATRONYMIC = "Николаевич" });
            var author2 = context.Authors.Add(new Domain.Entities.Author { A_COUNTRY = "Р.Ф.", A_DATE_BIRTH = DateTime.Parse("20.03.1809"), A_FIRST_NAME = "Гоголь", A_NAME = "Николай", A_PATRONYMIC = "Васильевич" });
            var author3 = context.Authors.Add(new Domain.Entities.Author { A_COUNTRY = "Р.Ф.", A_DATE_BIRTH = DateTime.Parse("24.11.1801"), A_FIRST_NAME = "Даль", A_NAME = "Владимир", A_PATRONYMIC = "Иванович" });
            var g1 = context.Genres.Add(new Domain.Entities.Genre { NAME_GENRE = "Научная литература" });
            var g2 = context.Genres.Add(new Domain.Entities.Genre { NAME_GENRE = "Художественная литература" });

            context.SaveChanges();

            var book1 = context.Books.Add(new Domain.Entities.Book
            {
                AUTHOR_ID = author1.ID_AUTHOR,
                PUBLISHING_HOUSE_ID = publish.ID_PUBLISHING_HOUSE,
                GENRE_ID = g1.ID_GENRE,
                NAME_BOOK = "Война и мир",
                YEAR_PUB = "1825",
                ISBN = 1
            });

            var book2 = context.Books.Add(new Domain.Entities.Book
            {
                AUTHOR_ID = author2.ID_AUTHOR,
                PUBLISHING_HOUSE_ID = publish.ID_PUBLISHING_HOUSE,
                GENRE_ID = g1.ID_GENRE,
                NAME_BOOK = "Мертвые души",
                YEAR_PUB = "1865",
                ISBN = 1
            });


            var book3 = context.Books.Add(new Domain.Entities.Book
            {
                AUTHOR_ID = author3.ID_AUTHOR,
                PUBLISHING_HOUSE_ID = publish.ID_PUBLISHING_HOUSE,
                GENRE_ID = g2.ID_GENRE,
                NAME_BOOK = "Словарь Даля",
                YEAR_PUB = "1925",
                ISBN = 1
            });


            context.SaveChanges();


            base.Seed(context);
        }
    }
}
