using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected string URL;

        protected string mantis_bv;
        public NavigatorHelper Navigator { get; set; }
        public AuthHelper authHelper { get; set; }
        public ProjectManagementHelper projectManagementHelper { get; set; }
        public RegistrationHelper Registration { get; set; }



        public FtpHelper Ftp { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            mantis_bv = "2.25.4";
            URL = "http://localhost/";
            baseURL = URL + "mantisbt-" + mantis_bv + "/login_page.php";
            Navigator = new NavigatorHelper(this, baseURL, mantis_bv);
            authHelper = new AuthHelper(this);
            projectManagementHelper = new ProjectManagementHelper(this);
        }

         ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
            }
        }
        public static ApplicationManager GetInstance()
        {
            if(! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}