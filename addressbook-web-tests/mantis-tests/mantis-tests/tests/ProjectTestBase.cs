using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class ProjectManagementTestBase : AuthTestBase
    {
        [TestFixtureSetUp]
        public void SetUpProjectManagement()
        {
            app.Navigator.OpenManageOverviewPage();
            app.Navigator.OpenProjectControlPage();
        }
    }
}