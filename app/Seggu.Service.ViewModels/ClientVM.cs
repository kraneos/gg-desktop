namespace Seggu.Service.ViewModels
{
    public class ClientVM : ParseViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string CellPhone { get; set; }
    }
}