using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeleteContactFromGroups : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest()
        {
            app.Groups.CheckExistGroup();
            app.Contacts.ChectExistContact();

            GroupData group = GroupData.GetAll()[0];
            app.Contacts.NoContactsInTheGroup(group);
           List<ContactData> oldList = group.GetContacts();
            ContactData contact = group.GetContacts().First();


            app.Contacts.DeleteContactFromGroup(contact, group);


            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}