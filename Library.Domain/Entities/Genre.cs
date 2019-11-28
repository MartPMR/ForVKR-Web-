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

    public class Genre
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int ID_GENRE { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        [Display(Name = "Название")]
        public string NAME_GENRE { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual List<Book> book { get; set; }
    }
}
