using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalStore.Models
{
    public partial class TypesOfProduct
    {
        public TypesOfProduct()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int AnimalId { get; set; }
        public int TypeOfTypeId { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual TypeOfType TypeOfType { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
