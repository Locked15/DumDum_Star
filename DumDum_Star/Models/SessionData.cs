using DumDum_Star.Models.Entities;

namespace DumDum_Star.Models
{
    public class SessionData
    {
        public static Choom? CurrentChoom { get; private set; }

        public static string GetHeaderText()
        {
            if (CurrentChoom == null)
                return "Гость";

            return CurrentChoom.Login;
        }
    }
}
