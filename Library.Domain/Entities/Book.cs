using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int ID_BOOK { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        public string NAME_BOOK { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        public int? AUTHOR_ID { get; set; }
        [ForeignKey("AUTHOR_ID")]
        [HiddenInput(DisplayValue = false)]
        public virtual Author author_books { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        public int? PUBLISHING_HOUSE_ID { get; set; }
        [ForeignKey("PUBLISHING_HOUSE_ID")]
        [HiddenInput(DisplayValue = false)]
        public virtual Publishing publishing_houses { get; set; }

        [Display(Name = "Год")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        public string YEAR_PUB { get; set; }

        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        public int ISBN { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        public int? GENRE_ID { get; set; }
        [ForeignKey("GENRE_ID")]
        [HiddenInput(DisplayValue = false)]
        public virtual Genre genre_books { get; set; }
    }
}
