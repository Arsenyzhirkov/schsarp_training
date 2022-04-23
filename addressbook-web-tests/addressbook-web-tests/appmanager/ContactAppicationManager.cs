using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected ContactLoginHelper contactLoginHelper;
        protected ContactNavigationHelper contactnavigator;
        protected ContactHelper contactHelper;

        public ContactApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";

            contactLoginHelper = new ContactLoginHelper(this);
            contactnavigator = new ContactNavigationHelper(this, baseURL);
            contactHelper = new ContactHelper(this);
        }
            public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public void Stop()
        {
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
        }

        public ContactLoginHelper Auth
        {
            get
            {
                return contactLoginHelper;
            }
        }
        public ContactNavigationHelper Navigator
        {
            get
            {
                return contactnavigator;
            }
        }
        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }
    }
}
