using Seggu.Service.ViewModels;

namespace Seggu.Service.Services
{
    public class BatchElement<T> where T : ParseViewModel
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public T Body { get; set; }
    }
}