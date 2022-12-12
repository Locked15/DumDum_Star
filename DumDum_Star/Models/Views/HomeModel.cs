using DumDum_Star.Models.Entities;

namespace DumDum_Star.Models.Views
{
    public class HomeModel
    {
        public string? Search { get; set; }

        public double LimitLoad { get; set; }

        public int ManufacturerId { get; set; }

        public int TypeId { get; set; }

        public int CurrentPage { get; set; } = 1;

        public List<CyberWare> AvailableCyberWares { get; set; } = Enumerable.Empty<CyberWare>().ToList();

        public List<List<CyberWare>> SplitCollectionToSubCollectionsByDivider(int divider)
        {
            var first = new List<List<CyberWare>>(1);
            foreach (var item in AvailableCyberWares)
            {
                var index = AvailableCyberWares.IndexOf(item);
                index = index != 0 ? index - 1 : 1;

                if ((index - 1) % divider == 0)
                {
                    first.Add(new(divider));
                    first.LastOrDefault()?.Add(item);
                }
                else
                {
                    first.LastOrDefault()?.Add(item);
                }
            }

            return first;
        }
    }
}
