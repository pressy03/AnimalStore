using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalStore.Models
{
    public partial class Address
    {
        public Address()
        {
            Clients = new HashSet<Client>();
        }

        public int AddressId { get; set; }
        public string AddressName { get; set; }
        public int TownId { get; set; }

        public virtual Town Town { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
