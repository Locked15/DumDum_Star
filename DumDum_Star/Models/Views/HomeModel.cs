using DumDum_Star.Models.Entities;

namespace DumDum_Star.Models.Views
{
    public class HomeModel
    {
        public string? Search { get; set; }

        public double LimitLoad { get; set; }

        public List<CyberWare> AvailableCyberWares { get; set; } = Enumerable.Empty<CyberWare>().ToList();
    }
}
