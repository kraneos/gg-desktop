using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Dtos
{
    [Serializable]
    public class AttachedFileDto : EntityWithIdDto
    {
        public string FilePath { get; set; }
        public int CasualtyId { get; set; }
        public int EndorseId { get; set; }
        public int PolicyId { get; set; }
        public int CashAccountId { get; set; }
    }
}
