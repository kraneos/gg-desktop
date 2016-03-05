namespace Seggu.Service
{
    public class ClientVM
    {
        public string ObjectId { get; set; }
        public DateVM CreatedAt { get; set; }
        public DateVM UpdatedAt { get; set; }
        public DateVM LocallyUpdatedAt { get; set; }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string CellPhone { get; set; }
    }
}