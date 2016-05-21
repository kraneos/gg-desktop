using Seggu.Service.ViewModels;

namespace Seggu.Service.Services
{
    public class BatchResponse
    {
        public BatchElementResponseVM Success { get; set; }
        public ErrorMessage Error { get; set; }
    }

    public class ErrorMessage
    {
        public int Code { get; set; }
        public string Error { get; set; }
    }
}