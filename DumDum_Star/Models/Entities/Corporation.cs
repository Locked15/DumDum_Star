using System;
using System.Collections.Generic;

namespace DumDum_Star.Models.Entities
{
    public partial class Corporation
    {
        public Corporation()
        {
            CyberWares = new HashSet<CyberWare>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? MonetaryValue { get; set; }
        public int? Members { get; set; }

        public virtual ICollection<CyberWare> CyberWares { get; set; }
    }
}
