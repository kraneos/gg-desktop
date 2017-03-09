using Seggu.Service.ViewModels;
using System;

namespace Seggu.Service.Services
{
    public class BatchElement<T> where T : ViewModel
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public T Body { get; set; }
    }
}