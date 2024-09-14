using System.Net;

namespace HisabPro.DTO.Model
{
    public class ResponseDTO<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }
    }
}
