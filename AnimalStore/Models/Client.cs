using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalStore.Models
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? ClientCardId { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }

        public virtual Address Address { get; set; }
        public virtual ClientCard ClientCard { get; set; }
    }
}
