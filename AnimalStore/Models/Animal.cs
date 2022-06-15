using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalStore.Models
{
    public partial class Animal
    {
        public Animal()
        {
            TypesOfProducts = new HashSet<TypesOfProduct>();
        }

        public int AnimalId { get; set; }
        public string AnimalName { get; set; }

        public virtual ICollection<TypesOfProduct> TypesOfProducts { get; set; }
    }
}
