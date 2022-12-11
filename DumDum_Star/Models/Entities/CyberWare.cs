using System;
using System.Collections.Generic;

namespace DumDum_Star.Models.Entities
{
    public partial class CyberWare
    {
        public CyberWare()
        {
            CyberWareMessages = new HashSet<CyberWareMessage>();
        }

        public int Id { get; set; }
        public int? TypeId { get; set; }
        public int? TargetId { get; set; }
        public int? ManufacturerId { get; set; }
        public int Quantity { get; set; }
        public bool? Custom { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public float? LoadLevel { get; set; }
        public string? Image { get; set; }

        public virtual Corporation? Manufacturer { get; set; }
        public virtual CyberWareTarget? Target { get; set; }
        public virtual CyberWareType? Type { get; set; }
        public virtual ICollection<CyberWareMessage> CyberWareMessages { get; set; }
    }
}
