using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalStore.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int TypeId { get; set; }
        public int OrderedQuantity { get; set; }

        public virtual TypesOfProduct Type { get; set; }
    }
}
