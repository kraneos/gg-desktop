using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parse;

namespace Seggu.Service.Tests
{
    [TestClass]
    public class ExampleTests
    {
        [TestMethod]
        public async void Testing()
        {
            ParseClient.Initialize(new ParseClient.Configuration
            {
                ApplicationId = "seggu-api",
                Server = "http://seggu-api-test.herokuapp.com/parse/"
            });

            await ParseUser.LogInAsync("apolo", "seggu2016");
                
            var test2 = await new ParseQuery<ParseObject>("Test2").FirstAsync();

            var test1 = new Parse.ParseObject("Test1");
            test1["test2"] = test2;
            test1["name"] = "pepe";
            test1.ACL = new ParseACL(ParseUser.CurrentUser);
            await test1.SaveAsync();
        }
    }
}
