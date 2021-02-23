using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqStuff.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class QueryExpressionTests
    {
        [TestMethod]
        public void SimpleQueryExpressionTests()
        {
            IEnumerable<MemberInfo> members = typeof(string).GetMembers();

            members = (from item in members 
                      where item.Name.StartsWith("Get") 
                      select item);

            Assert.IsTrue(
                  (from item in members
                       where item.Name.StartsWith("Get")
                       select item).SequenceEqual(members));
        }
    }
}
