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
        public string CasualtyId { get; set; }
        public string EndorseId { get; set; }
        public string PolicyId { get; set; }
        public string CashAccountId { get; set; }
    }
}
