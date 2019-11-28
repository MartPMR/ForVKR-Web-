using Library.Domain.Entities;
using Library.Domain.Entities;
using System.Web;

namespace Library.Web.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}