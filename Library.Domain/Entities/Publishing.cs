using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Library.Domain.Entities;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Publishing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int ID_PUBLISHING_HOUSE { get; set; }
        public string NAME_P_H { get; set; }
        public string ADRESS_P_H { get; set; }
        public string PHONE { get; set; }
        public virtual List<Book> books { get; set; }
    }
}
