namespace Seggu.Service
{
    public class BatchResponse<T>
    {
        public T Success { get; set; }
        public T Error { get; set; }
    }
}