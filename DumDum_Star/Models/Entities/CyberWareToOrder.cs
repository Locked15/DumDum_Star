using System.ComponentModel.DataAnnotations;

namespace DumDum_Star.Models.Entities
{
    public partial class CyberWareToOrder
    {
        [Key]
        public int Id { get; set; }
        public int CyberWareId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }

        public virtual CyberWare CyberWare { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;

        public decimal FinalPrice
        {
            get
            {
                return CyberWare.Price * Count;
            }
        }
    }
}
