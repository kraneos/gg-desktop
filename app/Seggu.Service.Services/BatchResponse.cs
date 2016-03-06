namespace Seggu.Service.Services
{
    public class BatchResponse<T>
    {
        public T Success { get; set; }
        public ErrorMessage Error { get; set; }
    }

    public class ErrorMessage
    {
        public int Code { get; set; }
        public string Error { get; set; }
    }
}