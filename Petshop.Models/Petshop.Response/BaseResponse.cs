using System.Net;

namespace PetShop.Petshop.Models.Petshop.Requests
{
    public class BaseResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
    }
}
