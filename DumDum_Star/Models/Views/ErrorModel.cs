using System.Net;

namespace DumDum_Star.Models.Views
{
    public class ErrorModel
    {
        public Guid ID { get; init; }

        public HttpStatusCode Code { get; init; }

        public string? Message { get; private set; }

        public void GenerateMessage()
        {
            switch (Code)
            {
                case HttpStatusCode.NotFound:
                    Message = "Requested page isn't found.\n\nTurn back, while you can.";
                    break;
            }
        }
    }
}
