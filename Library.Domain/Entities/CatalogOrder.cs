using Library.Domain.Entities;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    /// <summary>Книжый заказ</summary>
    public class CatalogOrder : IdentEntity<Guid>
    {
        /// <summary>Имя заказчика</summary>
        public string UserName { get; set; }
        /// <summary>Перечень заказа</summary>
        public List<CatalogOrderItem> OrderItems { get; set; }
    }
}
