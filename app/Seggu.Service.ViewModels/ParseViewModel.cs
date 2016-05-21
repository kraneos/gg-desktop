using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public abstract class ViewModelBase
    {
        public DateVM CreatedAt { get; set; }
        public DateVM UpdatedAt { get; set; }
    }

    public abstract class ViewModel : ViewModelBase
    {
        public string ObjectId { get; set; }
    }

    public abstract class KeyValueViewModel : ViewModel
    {
        public string Name { get; set; }
    }
}
