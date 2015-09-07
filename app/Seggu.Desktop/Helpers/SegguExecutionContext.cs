using Seggu.Data;
using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Desktop.Helpers
{
    public sealed class SegguExecutionContext
    {
        private SegguExecutionContext()
        {
        }

        private static volatile object lockObj = new object();
        private static volatile SegguExecutionContext instance;

        public static SegguExecutionContext Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new SegguExecutionContext();
                    }
                }
                return instance;
            }
        }

        public UserDto CurrentUser { get; set; }
    }
}
