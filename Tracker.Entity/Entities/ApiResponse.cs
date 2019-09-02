namespace Tracker.Entity.Entities
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool Error { get; set; }
    }
}