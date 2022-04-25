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
    }
}
