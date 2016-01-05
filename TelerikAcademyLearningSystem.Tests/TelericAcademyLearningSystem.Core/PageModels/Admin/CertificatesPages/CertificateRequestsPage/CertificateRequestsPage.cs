namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateRequestsPage
{
    using System;
    using System.Linq;
    using ArtOfTest.WebAii.Core;

    public partial class CertificateRequestsPage : AdminPage
    {
        private readonly int columnUsernameNumber = 2;

        public CertificateRequestsPage(Manager manager)
            : base(manager)
        {
            this.PageUrl = "http://stage.telerikacademy.com/Administration_Certificates/CertificateRequests";
        }

        public void AddNewCertificateRequest(string courseTrack, string username, string names)
        {
            this.Wait.Explicit(this.ExplicitTimeout);
            bool usernameExists = this.CheckNameExistsInGrid(username, this.columnUsernameNumber);

            if (usernameExists && !string.IsNullOrEmpty(username))
            {
                this.DeleteGridRow(username, this.columnUsernameNumber);
                this.Manager.ActiveBrowser.Refresh();
                this.Wait.Explicit(this.ExplicitTimeout);
            }

            this.AddButton.Click();
            this.SelectCourseTrack.Click();
            this.Wait.Explicit(this.ExplicitTimeout);
            this.CourseTrackList.Items.Where(i => i.TextContent == courseTrack).FirstOrDefault().Click();
            this.SimulateRealTyping(this.UsernameInput, username);
            this.SimulateRealTyping(this.UserFullnameInput, names);
            this.UpdateButton.Click();

            this.Wait.Explicit(this.ExplicitTimeout);
        }

        public void AddNewCertificateRequestWithoutCourseTrack(string username, string names)
        {
            this.Wait.Explicit(this.ExplicitTimeout);
            bool usernameExists = this.CheckNameExistsInGrid(username, this.columnUsernameNumber);

            if (usernameExists && !string.IsNullOrEmpty(username))
            {
                this.DeleteGridRow(username, this.columnUsernameNumber);
                this.Manager.ActiveBrowser.Refresh();
                this.Wait.Explicit(this.ExplicitTimeout);
            }

            this.AddButton.Click();
            this.Wait.Explicit(this.ExplicitTimeout);
            this.SimulateRealTyping(this.UsernameInput, username);
            this.Wait.Explicit(this.ExplicitTimeout);
            this.SimulateRealTyping(this.UserFullnameInput, names);
            this.UpdateButton.Click();

            this.Wait.Explicit(this.ExplicitTimeout);
        }
    }
}
