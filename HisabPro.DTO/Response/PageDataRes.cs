namespace HisabPro.DTO.Response
{
    public class PageDataRes<T>
    {
        public List<T> Data { get; set; }
        public int TotalData { get; set; }
    }
}
