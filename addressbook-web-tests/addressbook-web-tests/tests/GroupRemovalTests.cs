using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();
            if(!app.Groups.IsGroupCreate())
            {
                GroupData group = new GroupData("aaa");
                app.Groups.Create(group);
            }
            app.Groups.Remove(1);
        }
    }
}
