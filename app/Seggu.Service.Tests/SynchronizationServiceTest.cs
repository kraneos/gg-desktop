using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seggu.Service.Services;
using Seggu.Data;
using Moq;
using System.Diagnostics;

namespace Seggu.Service.Tests
{
    /// <summary>
    /// Summary description for SynchronizationServiceTest
    /// </summary>
    [TestClass]
    public class SynchronizationServiceTest
    {
        public SynchronizationServiceTest()
        {
            SynchronizationService.Initialize();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void SynchronizationServiceShouldExecuteWithoutErrors()
        {
            var eventLog = new EventLog();
            using (var context = new SegguDataModelContext("Data Source=.\\seggu.sqlite;"))
            {
                var syncService = new SynchronizationService(context, eventLog);
                syncService.SynchronizeParseEntities();
            }
        }
    }
}
