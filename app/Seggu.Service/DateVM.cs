using System;
using System.Runtime.Serialization;

namespace Seggu.Service
{
    [DataContract]
    public class DateVM
    {
        public static string dateFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
        public DateVM(DateTime date)
        {
            this.type = "Date";
            this.iso = date.ToString(dateFormat);
        }

        public DateVM()
        {
            this.type = "Date";
        }

        public static implicit operator DateVM(DateTime date)
        {
            return new DateVM(date);
        }

        public static implicit operator DateVM(DateTime? date)
        {
            return date.HasValue ? new DateVM(date.Value) : null;
        }

        public static implicit operator DateTime?(DateVM date)
        {
            return DateTime.ParseExact(date.iso, dateFormat, null);
        }

        private string type;

        [DataMember(Name = "__type")]
        public string Type
        {
            get { return this.type; }
            set {  }
        }

        private string iso;

        [DataMember]
        public string Iso
        {
            get { return iso; }
            set { iso = value; }
        }
    }
}