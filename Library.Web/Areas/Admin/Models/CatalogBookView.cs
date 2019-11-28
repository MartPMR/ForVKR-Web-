using Library.Domain.Entities;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.Admin.Models
{
    public class CatalogBookView
    {
        public Book Book { get; set; }
        public List<Author> Authors { get; set; }
    }
}