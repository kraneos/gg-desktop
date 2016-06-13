using System;

namespace Seggu.Domain
{
    public abstract class IdParseEntity : ParseEntity
    {
        public long Id { get; set; }
    }

    public abstract class ParseEntity
    {
        public string ObjectId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LocallyUpdatedAt { get; set; }
    }
}