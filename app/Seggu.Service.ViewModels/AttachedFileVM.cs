using Parse;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("AttachedFile")]
    public class AttachedFileVM : ViewModel
    {
        [ParseFieldName("filePath")]
        public string FilePath { get; set; }
        [ParseFieldName("policy")]
        public ParseObject Policy { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("endorse")]
        public ParseObject Endorse { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("casualty")]
        public ParseObject Casualty { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("cashAccount")]
        public ParseObject CashAccount { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("client")]
        public ParseObject Client { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
    }
}
