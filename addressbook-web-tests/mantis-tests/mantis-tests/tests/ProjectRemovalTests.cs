using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {

        [Test]
        public void RemoveProjectTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "admin"
            };


            if (app.API.GetProjectsList(account).Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "ААААААААААААА",
                    Description = "АААААААААААААААА",
                };
                app.API.Create(account, project);
            }

            List<ProjectData> oldList = app.API.GetProjectsList(account);

            app.projectManagementHelper.Remove(0);

            List<ProjectData> newList = app.API.GetProjectsList(account);

            ProjectData toBeRemoved = oldList[0];
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            foreach (ProjectData project in newList)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);

            Console.Out.Write(oldList.Count);
            Console.Out.Write(newList.Count);
        }
    }
}
