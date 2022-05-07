using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
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
            contact.Address2 = "123";
            contact.Phone2 = "123";
            contact.Notes = "123";

            app.Contacts.Create(contact);
        }

        [Test]

        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";
            contact.Nickname = "";
            contact.Title = "";
            contact.Company = "";
            contact.Address = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Work = "";
            contact.Fax = "";
            contact.Email = "";
            contact.Address2 = "";
            contact.Phone2 = "";
            contact.Notes = "";

            app.Contacts.Create(contact);
        }
    }
}
