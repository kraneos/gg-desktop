using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Service.ViewModels
{
    public abstract class ViewModel
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }

    public abstract class KeyValueViewModel : ViewModel
    {
        public string Name { get; set; }
    }
}
