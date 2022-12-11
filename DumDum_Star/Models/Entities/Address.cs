using System;
using System.Collections.Generic;

namespace DumDum_Star.Models.Entities
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string City { get; set; } = null!;
        public string? Region { get; set; }
        public string Street { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
