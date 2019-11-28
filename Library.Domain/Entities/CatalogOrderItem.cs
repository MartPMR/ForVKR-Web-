using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    /// <summary>Элемент заказа</summary>
    public class CatalogOrderItem : IdentEntity<Guid>
    {
        /// <summary>Ссылка на заказ</summary>
        public virtual CatalogOrder Order { get; set; }
        public Guid OrderID { get; set; }
        /// <summary>Ссылка на заказанную книгу</summary>
        public int BookID { get; set; }
        /// <summary>Число едениц</summary>
        public int Count { get; set; }
    }
}
