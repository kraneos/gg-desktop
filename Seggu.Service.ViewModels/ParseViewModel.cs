using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public abstract class ViewModelBase
    {
        //public DateVM CreatedAt { get; set; }
        //public DateVM UpdatedAt { get; set; }
    }

    public abstract class ViewModel : ParseObject
    {
        //public string ObjectId { get; set; }
    }

    public abstract class KeyValueViewModel : ViewModel
    {
        [ParseFieldName("name")]
        public string Name
        {
            get
            {
                return GetProperty<string>();
            }
            set
            {
                SetProperty<string>(value);
            }
        }
    }
}
