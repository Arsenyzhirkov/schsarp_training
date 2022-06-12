using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allContactsInfo;


        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData()
        {
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == (other.Firstname) && Lastname == (other.Lastname);

        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }
        public override string ToString()
        {
            return "firstname=" + Firstname + "\nlastname=" + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if
                (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname != other.Lastname)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            else return Firstname.CompareTo(other.Firstname);
        }


        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Id { get; set; }


        public string AllContactsInfo
        {
            get
            {
                if (allContactsInfo != null)
                {
                    return allContactsInfo;
                }
                else
                {
                    string allData = (CleanUpAllData(GetContacts(Firstname, Lastname, Address))
                        + CleanUpAllData(GetPhones(HomePhone, MobilePhone, WorkPhone))
                        + CleanUpAllData(GetEmails(Email, Email2, Email3))).Trim();

                    return allData;
                }
            }
            set
            {
                allContactsInfo = value;
            }
        }

        private string GetContacts(string firstname, string lastname, string address)
        {
            return CleanUpAllData(GetFullName(firstname, lastname))
                + CleanUpAllData(address);
        }


        private string GetFullName(string firstname, string lastname)
            {
            string bufer = "";
            if (firstname != null && firstname != "")
            {
                bufer = Firstname + " ";
            }
            if (lastname != null && lastname != "")
            {
                bufer = bufer + Lastname + " ";
            }
            return bufer.Trim();

        }

        private string GetPhones(string homePhone, string MobilePhone, string WorkPhone)
        {
            string bufer = "";
            if (homePhone != null && homePhone != "")
            {
                bufer = bufer + "H: " + HomePhone + "\r\n";
            }
            if (MobilePhone != null && MobilePhone != "")
            {
                bufer = bufer + "M: " + MobilePhone + "\r\n";
            }
            if (WorkPhone != null && WorkPhone != "")
            {
                bufer = bufer + "W: " + WorkPhone + "\r\n";
            }
            return bufer;

        }

        private string GetEmails(string email, string email2, string email3)
        {
            string bufer = "";

            if (email != null && email != "")
            {
                bufer = bufer +  email + "\r\n";
            }
            if (email2 != null && email2 != "")
            {
                bufer = bufer +  email2 + "\r\n";
            }
            if (email3 != null && email3 != "")
            {
                bufer = bufer + email3 + "\r\n";
            }
            return bufer;

        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ - () ]", "") +"\r\n";
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Trim() + "\r\n";
        }


    private string CleanUpAllData (string allData)
        {
            if (allData == null || allData == "")
            {
                return "";
            }
            return allData + "\r\n";
        }
}
}

