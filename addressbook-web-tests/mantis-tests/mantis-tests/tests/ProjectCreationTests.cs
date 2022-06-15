using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : ProjectManagementTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(15),
                Description = GenerateRandomString(15)
            };

            List<ProjectData> oldList = app.projectManagementHelper.GetProjectList();

            app.projectManagementHelper.Create(project);

            List<ProjectData> newList = app.projectManagementHelper.GetProjectList();

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