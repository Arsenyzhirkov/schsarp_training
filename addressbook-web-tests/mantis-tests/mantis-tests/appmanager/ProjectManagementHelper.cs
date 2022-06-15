using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }
        public void Create(ProjectData project)
        {
            CreationProject();
            FillProjectForm(project);
            SubmitProjectCreation();
            new WebDriverWait(driver, TimeSpan.FromSeconds(15))
                .Until(d => d.FindElements(By.XPath("(//table/tbody)[1]/tr")).Count > 0);

        }
        public void Remove(int index)
        {
            InitProjectEdit(index);
            RemoveProject();
            Confirm();
        }

        private void Confirm()
        {
            driver.FindElement(By.CssSelector("form.center input[type=\"submit\"]")).Click();
        }

        private void RemoveProject()
        {
            driver.FindElement(By.CssSelector("form#project-delete-form input[type=\"submit\"]")).Click();
        }

        private void InitProjectEdit(int index)
        {
            driver.FindElement(By.XPath($"(//table/tbody)[1]/tr[{index + 1}]/td/a")).Click();
        }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projectList = new List<ProjectData>();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//table/tbody)[1]/tr"));
            foreach (IWebElement element in elements)
            {
                projectList.Add(new ProjectData()
                {
                    Id = Regex.Match(element.FindElement(By.XPath("./td[1]/a")).GetAttribute("href"), "\\d+").Value,
                    Name = element.FindElement(By.XPath("./td[1]")).Text,
                    Description = element.FindElement(By.XPath("./td[5]")).Text
                });
            }
            return projectList;
        }
        public void CreationProject()
        {
            driver.FindElement(By.XPath("//form[@action=\"manage_proj_create_page.php\"]//button[@type=\"submit\"]")).Click();
        }
        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }
        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@type=\"submit\"]")).Click();
        }
    }
}