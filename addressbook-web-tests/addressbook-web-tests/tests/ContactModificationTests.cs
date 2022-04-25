using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("ARSENY1");
            newData.Middlename = "ARS1";
            newData.Lastname = "ZHIRKOV1";
            newData.Nickname = "ARSENY1";
            newData.Title = "1234";
            newData.Company = "1234";
            newData.Address = "1234";
            newData.Home = "333334";
            newData.Mobile = "83333333334";
            newData.Work = "124";
            newData.Fax = "124";
            newData.Email = "2@mail.ru";
            newData.Address2 = "124";
            newData.Phone2 = "124";
            newData.Notes = "124";

            app.Contacts.Modify(1, newData);
        }
    }
}
