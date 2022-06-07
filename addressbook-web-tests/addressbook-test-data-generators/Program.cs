using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;
using Excel = Microsoft.Office.Interop.Excel;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            List<GroupData> groups = new List<GroupData> ();
            List<ContactData> contacts = new List<ContactData>();


            if (type == "contacts")
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(15), TestBase.GenerateRandomString(15))
                    {
                        Address = TestBase.GenerateRandomString(25),
                    });
                }
            }

            else if (type == "groups")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
            }
            else
                Console.Out.Write("Unrecognized type " + type);

            if (format == "excel")
            {
                if (type == "contacts")
                    writeContactsToExcelFile(contacts, filename);

                else if (type == "groups")
                    writeGroupsToExcelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);

                if (format == "csv")
                {
                    if (type == "contacts")
                        writeContactsToCsvFile(contacts, writer);

                    else if (type == "groups")
                        writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    if (type == "contacts")
                        writeContactsToXmlFile(contacts, writer);

                    else if (type == "groups")
                        writeGroupsToXmlFile(groups, writer);

                }
                else if (format == "json")
                {
                    if (type == "contacts")
                        writeContactsToJsonFile(contacts, writer);

                    else if (type == "groups")
                        writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
                writer.Close();
            }

        }

        static void writeContactsToExcelFile(List<ContactData> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = app.ActiveSheet;

            int row = 1;
            {
                foreach (ContactData contact in contacts)
                {
                    sheet.Cells[row, 1] = contact.Firstname;
                    sheet.Cells[row, 2] = contact.Lastname;
                    row++;
                }
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }




        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;


            int row = 1;
           foreach(GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }

           string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(string.Format("${0},${1},${2}",
                    contact.Firstname, contact.Lastname, contact.Address));
            }
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach(GroupData group in groups)
            {
                writer.WriteLine(string.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }


        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
     }
}
