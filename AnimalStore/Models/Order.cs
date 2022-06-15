using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalStore.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? ClientCardId { get; set; }
        public bool Fullfilled { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual ClientCard ClientCard { get; set; }
    }
}
