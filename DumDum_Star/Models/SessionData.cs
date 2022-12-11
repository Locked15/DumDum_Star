using DumDum_Star.Models.Entities;

namespace DumDum_Star.Models
{
    public class SessionData
    {
        public static Choom? CurrentChoom { get; private set; }

        public static Order? CurrentOrder { get; private set; }

        public static string GetHeaderText()
        {
            if (CurrentChoom == null)
                return "Гость";

            return CurrentChoom.Login;
        }

        public static string GetBasketIconPath()
        {
            if (CurrentOrder?.CyberWareToOrders.Any() ?? false)
                return "./icons/light/header/basket/basket-new.png";

            else
                return "./icons/light/header/basket/basket.png";
        }
    }
}
