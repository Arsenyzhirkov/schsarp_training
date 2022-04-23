using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookContactTest
{
    [TestFixture]
    public class ContactCreationTests : TestBaseContact
    {
        
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountDataContact("admin","secret"));
            GoToContactsPage();
            ContactData contact = new ContactData("ARSENY");
            contact.Middlename = "ARS";
            contact.Lastname = "ZHIRKOV";
            contact.Nickname = "ARSENY";
            contact.Title = "123";
            contact.Company = "123";
            contact.Address = "123";
            contact.Home = "333333";
            contact.Mobile = "83333333333";
            contact.Work = "123";
            contact.Fax = "123";
            contact.Email = "1@mail.ru";
            contact.Bday = "1";
            contact.Bmonth = "January";
            contact.Byear = "2020";
            contact.Aday = "1";
            contact.Amonth = "January";
            contact.Ayear = "2020";
            contact.Address2 = "123";
            contact.Phone2 = "123";
            contact.Notes = "123";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();
        }
    }
}
