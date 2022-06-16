using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using mantis_tests.Mantis;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager){ }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjectsList(AccountData account)
        {

            List<ProjectData> projects = new List<ProjectData>();
            MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
            Mantis.ProjectData[] mantisProjects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (Mantis.ProjectData project in mantisProjects)
            {
                projects.Add(new ProjectData()
                {
                    Id = project.id,
                    Name = project.name,
                    Description = project.description
                });

            }
            return projects;
        }
        public void Create(AccountData account, ProjectData project)
        {
            MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
            client.mc_project_add(account.Name, account.Password, new Mantis.ProjectData()
            {
                name = project.Name,
                description = project.Description
            });
        }
        public void Delete(AccountData account, ProjectData project)
        {
            MantisConnectPortTypeClient client = new MantisConnectPortTypeClient();
            client.mc_project_delete(account.Name, account.Password, project.Id);
        }
    }
}
