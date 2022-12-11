using System;
using System.Collections.Generic;

namespace DumDum_Star.Models.Entities
{
    public partial class CyberWareMessage
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int CyberWareId { get; set; }
        public float Rank { get; set; }
        public string? Message { get; set; }

        public virtual Choom Author { get; set; } = null!;
        public virtual CyberWare CyberWare { get; set; } = null!;
    }
}
