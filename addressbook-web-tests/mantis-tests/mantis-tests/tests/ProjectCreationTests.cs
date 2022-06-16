using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : ProjectManagementTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "admin"
            };

            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(15),
                Description = GenerateRandomString(15)
            };

            List<ProjectData> oldList = app.API.GetProjectsList(account);

            app.projectManagementHelper.Create(project);

            List<ProjectData> newList = app.API.GetProjectsList(account);

            oldList.Add(project);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);

            Console.Out.Write(oldList.Count);
            Console.Out.Write(newList.Count);
        }
    }
}