using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mantis_tests
{
    public class AuthHelper : HelperBase
    {
        public AuthHelper(ApplicationManager manager) : base(manager) { }


        public void Login(AccountData account)
        {
            InsertLogin(account);
            Confirm();
            InsertPassword(account);
            Confirm();
        }
        public void InsertLogin(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
        }

        private void Confirm()
        {
            driver.FindElement(By.XPath("//input[@type=\"submit\"]")).Click();
        }

        public void InsertPassword(AccountData account)
        {
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
        }
    }
}