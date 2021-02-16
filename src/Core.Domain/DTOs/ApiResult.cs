namespace Core.Domain.DTOs
{
    /// <summary>
    /// Class used as a return object for all API calls
    /// </summary>
    /// <typeparam name="T">The type of object to return</typeparam>
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public T Value { get; set; }
    }
}
