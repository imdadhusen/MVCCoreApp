namespace HisabPro.DTO.Model
{
    public class ErrorDTO
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
