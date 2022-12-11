using System;
using System.Collections.Generic;

namespace DumDum_Star.Models.Entities
{
    public partial class CyberWareType
    {
        public CyberWareType()
        {
            CyberWares = new HashSet<CyberWare>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<CyberWare> CyberWares { get; set; }
    }
}
