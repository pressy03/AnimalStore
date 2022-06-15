using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalStore.Models
{
    public partial class ClientCard
    {
        public ClientCard()
        {
            Clients = new HashSet<Client>();
            Orders = new HashSet<Order>();
        }

        public int CardId { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
