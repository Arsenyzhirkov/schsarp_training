using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : ProjectManagementTestBase
    {

        [Test]
        public void RemoveProjectTest()
        {

            if (app.projectManagementHelper.GetProjectList().Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "АААААААА",
                    Description = "ААААААААА",
                };
                app.projectManagementHelper.Create(project);
            }

            List<ProjectData> oldList = app.projectManagementHelper.GetProjectList();

            app.projectManagementHelper.Remove(0);

            List<ProjectData> newList = app.projectManagementHelper.GetProjectList();

            ProjectData toBeRemoved = oldList[0];
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);

            Console.Out.Write(oldList.Count);
            Console.Out.Write(newList.Count);
        }
    }
}