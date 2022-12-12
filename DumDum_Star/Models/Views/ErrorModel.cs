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
                case HttpStatusCode.Unauthorized:
                    Message = "It looking like you trying to connect to pages, that not acceptable to you.\n\nRun, while you can.";
                    break;

                default:
                    Message = "Error? Where?\n\n This errors isn't what you looking for.";
                    break;
            }
        }
    }
}
