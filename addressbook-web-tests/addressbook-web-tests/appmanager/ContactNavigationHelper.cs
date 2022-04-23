﻿using System;
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
    public class ContactNavigationHelper : ContactHelperBase
    {
        private string baseURL;

        public ContactNavigationHelper(ContactApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToContactsPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}