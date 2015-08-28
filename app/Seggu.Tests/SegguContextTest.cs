using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seggu.Data;

namespace Seggu.Tests
{
    [TestClass]
    public class SegguContextTest
    {
        [TestMethod]
        public void TestContextInitialization()
        {
            using (var context = new SegguDataModelContainer())
            {
                foreach (var item in context.Users)
                {
                    var a = item;
                }
            }
        }
    }
}
