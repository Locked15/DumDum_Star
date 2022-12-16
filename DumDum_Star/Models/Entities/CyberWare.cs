using System.ComponentModel.DataAnnotations;

namespace DumDum_Star.Models.Entities
{
    public partial class CyberWare
    {
        public CyberWare()
        {
            CyberWareMessages = new HashSet<CyberWareMessage>();
            CyberWareToOrders = new HashSet<CyberWareToOrder>();
        }

        public int Id { get; set; }

        public int? TypeId { get; set; }

        public int? TargetId { get; set; }

        public int? ManufacturerId { get; set; }
        [Required]
        [Range(0, 1024)]
        public int Quantity { get; set; }

        public bool? Custom { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public string? Image { get; set; }

        public float? LoadLevel { get; set; }

        public string? Description { get; set; }

        public virtual Corporation? Manufacturer { get; set; }
        public virtual CyberWareTarget? Target { get; set; }
        public virtual CyberWareType? Type { get; set; }
        public virtual ICollection<CyberWareMessage> CyberWareMessages { get; set; }
        public virtual ICollection<CyberWareToOrder> CyberWareToOrders { get; set; }

        public double Ranking
        {
            get
            {
                var rank = CyberWareMessages.Sum(r => r.Rank) / CyberWareMessages.Count;

                // Check to NaN.
                if (double.IsNaN(rank))
                    return 0.0;
                else
                    return rank;
            }
        }
    }
}
