using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalStore.Models
{
    public partial class TypeOfType
    {
        public TypeOfType()
        {
            TypesOfProducts = new HashSet<TypesOfProduct>();
        }

        public int TypeOfTypeId { get; set; }
        public string TypeOfTypeName { get; set; }

        public virtual ICollection<TypesOfProduct> TypesOfProducts { get; set; }
    }
}
