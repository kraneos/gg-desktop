using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Seggu.Data
{
    public sealed class SegguContainer
    {
        private static volatile SegguDataModelContainer instance;
        private static readonly object objectlockCheck = new object();
        private SegguContainer() { }

        public static SegguDataModelContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (objectlockCheck)
                    {
                        if (instance == null)
                        {
                            instance = new SegguDataModelContainer();
                            //instance.Configuration.LazyLoadingEnabled = false;
                            //instance.Configuration.AutoDetectChangesEnabled = false;
                            //instance.Configuration.ValidateOnSaveEnabled = false;
                            ((IObjectContextAdapter)instance).ObjectContext.CommandTimeout = 180;
                        }
                    }
                }
                return instance;
            }
        }

        public static void RefreshSet<T>() where T : class
        {
            var objectContext = ((IObjectContextAdapter)instance).ObjectContext;
            objectContext.Refresh(RefreshMode.StoreWins, instance.Set<T>());
        }
    }
}
