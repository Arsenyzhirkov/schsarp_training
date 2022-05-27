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
            app.Navigator.GoToHomePage();
            if (!app.Contacts.IsContactCreate())
            {
                ContactData contact = new ContactData("ARSENY", "ZHIRKOV");
                app.Contacts.Create(contact);
            }
            ContactData newData = new ContactData("ARSENY1","ZHIRKOV1");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, newData);

           // Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //foreach (ContactData contact in newContacts)
            {
                //if
                    //(contact.Id == oldData.Id)
                {
                    //Assert.AreEqual(newData.Firstname, contact.Firstname);
                }
            }
        }
    }
}
