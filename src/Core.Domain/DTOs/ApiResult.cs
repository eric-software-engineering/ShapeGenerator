namespace Core.Domain.DTOs
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public T Value { get; set; }
    }
}
