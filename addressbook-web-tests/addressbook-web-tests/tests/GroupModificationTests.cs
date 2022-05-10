using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupCreate())
            {
                GroupData group = new GroupData("aaa");
                app.Groups.Create(group);
            }
            
                GroupData newData = new GroupData("zzz");
                newData.Header = null;
                newData.Footer = null;

                app.Groups.Modify(1, newData);
            }
        }
    }
