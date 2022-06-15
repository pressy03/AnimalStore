using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalStore.Models
{
    public partial class Town
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }

        public int TownId { get; set; }
        public string TownName { get; set; }
        public string PostCode { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
