namespace Seggu.Service
{
    public class BatchElement<T> where T : new()
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public T Body { get; set; }
    }
}