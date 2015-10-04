using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seggu.Data;
using System.Linq;
namespace Seggu.Tests
{
    [TestClass]
    public class SegguContextTest
    {
        [TestMethod]
        public void TestContextInitialization()
        {
            using (var context = new SegguDataModelContext())
            {
                var vt = context.VehicleTypes.First();
            }
        }
    }
}
