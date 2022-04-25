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
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData newData = new ContactData("ARSENY");
            newData.Middlename = "ARS";
            newData.Lastname = "ZHIRKOV";
            newData.Nickname = "ARSENY";
            newData.Title = "123";
            newData.Company = "123";
            newData.Address = "123";
            newData.Home = "333333";
            newData.Mobile = "83333333333";
            newData.Work = "123";
            newData.Fax = "123";
            newData.Email = "1@mail.ru";
            newData.Address2 = "123";
            newData.Phone2 = "123";
            newData.Notes = "123";

            app.Contacts.Modify(1, newData);
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
