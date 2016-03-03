using System;

namespace Seggu.Domain
{
    public abstract class ParseEntity : IdEntity
    {
        public string ObjectId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LocallyUpdatedAt { get; set; }
    }
}