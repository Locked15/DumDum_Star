using System;
using System.Collections.Generic;

namespace DumDum_Star.Models.Entities
{
    public partial class CyberWareTarget
    {
        public CyberWareTarget()
        {
            CyberWares = new HashSet<CyberWare>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CyberWare> CyberWares { get; set; }
    }
}
