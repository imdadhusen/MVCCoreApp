using System.Net;

namespace HisabPro.DTO.Model
{
    public class ResponseDTO<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }

        public ResponseDTO() { }

        public ResponseDTO(HttpStatusCode statusCode, string message, T response = default)
        {
            StatusCode = statusCode;
            Message = message;
            Response = response;
        }
    }
}
