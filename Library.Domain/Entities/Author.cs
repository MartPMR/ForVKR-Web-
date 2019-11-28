using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int ID_AUTHOR { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        [Display(Name = "Фамилия")]
        public string A_NAME { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        [Display(Name = "Имя")]
        public string A_FIRST_NAME { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        [Display(Name = "Отчество")]
        public string A_PATRONYMIC { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        //[DataType(DataType.DateTime)]
        [Display(Name = "Дата рождения")]
        public DateTime A_DATE_BIRTH { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните поле")]
        [Display(Name = "Страна")]
        public string A_COUNTRY { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual List<Book> books { get; set; }
    }
}
