namespace Api.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; } = default(T);
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}