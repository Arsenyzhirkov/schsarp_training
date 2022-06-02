using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailedInformationTests : AuthTestBase
    {
        [Test]

        public void TestContactDetailsInformation()
        {
            string fromEdit = app.Contacts.GetContactInformationFromEdit(0);
            string fromDetails = app.Contacts.GetContactInformationFromDetails(0);

            Assert.AreEqual(fromEdit, fromDetails);
        }
    }
}
