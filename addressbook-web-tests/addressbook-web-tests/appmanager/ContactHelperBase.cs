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
    public class ContactHelperBase
    {
        protected IWebDriver driver;
        protected ContactApplicationManager manager;

        public ContactHelperBase(ContactApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
    }
}