using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mantis_tests
{
    public class NavigatorHelper : HelperBase
    {
        private readonly string baseURL;
        private readonly string mantis_bv;

        public NavigatorHelper(ApplicationManager manager, string baseURL, string mantis_bv) : base(manager)
        {
            this.baseURL = baseURL;
            this.mantis_bv = mantis_bv;
        }
        public NavigatorHelper OpenHomePage()
        {
            if (driver.Url == baseURL)
            {
                return this;
            }
            driver.Navigate().GoToUrl(baseURL);
            return this;
        }
        public NavigatorHelper OpenManageOverviewPage()
        {
            driver.FindElement(By.XPath($"//a[@href='/mantisbt-{mantis_bv}/manage_overview_page.php']")).Click();

            return this;
        }
        public NavigatorHelper OpenProjectControlPage()
        {
            driver.FindElement(By.XPath($"//a[@href='/mantisbt-{mantis_bv}/manage_proj_page.php']")).Click();

            return this;
        }
    }
}