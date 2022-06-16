using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string URL;
        protected string baseURL;
        protected string mantis_bv;
        public NavigatorHelper Navigator { get; set; }
        public AuthHelper authHelper { get; set; }
        public ProjectManagementHelper projectManagementHelper { get; set; }
        public APIHelper API { get; set; }

        private static ThreadLocal <ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            mantis_bv = "2.25.4";
            URL = "http://localhost/";
            baseURL = URL + "mantisbt-" + mantis_bv + "/login_page.php";
            Navigator = new NavigatorHelper(this, baseURL, mantis_bv);
            authHelper = new AuthHelper(this);
            projectManagementHelper = new ProjectManagementHelper(this);
            API = new APIHelper(this);
        }

     
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
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
