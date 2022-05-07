using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
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
            newData.Fax = null;
            newData.Email = null;
            newData.Address2 = null;
            newData.Phone2 = null;
            newData.Notes = null;

            app.Contacts.Modify(1, newData);
        }
    }
}
