    using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Seggu.Api.Data.Tests
{
    [TestClass]
    public class SegguContextTest
    {
        [TestMethod]
        public void ContextShouldBeCreated()
        {
            var context = SegguContext.Create();
            using (var trx = context.Database.BeginTransaction())
            {
                var res = context.Clients;
                foreach (var item in res)
                {
                    // Do Something.
                }

                Assert.IsNotNull(res);
            }
        }
    }
}
