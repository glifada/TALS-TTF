namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificatesPage
{
    using System;
    using System.Linq;
    using ArtOfTest.WebAii.Core;

    public partial class CertificatesPage : AdminPage
    {
        private readonly int columnUsernameNumber = 3;

        public CertificatesPage(Manager manager)
            : base(manager)
        {
            this.PageUrl = "http://stage.telerikacademy.com/Administration_Certificates/Certificates";
        }

        public void AddNewCertificate(string certificateType, string fullname, string username)
        {
            this.Wait.Explicit(this.ExplicitTimeout);
            bool usernameExists = this.CheckNameExistsInGrid(username, this.columnUsernameNumber);

            if (usernameExists && !string.IsNullOrEmpty(username))
            {
                this.DeleteGridRow(username, this.columnUsernameNumber);
                this.Wait.Explicit(this.ExplicitTimeout);
            }

            this.AddButton.Click();
            this.SelectCertificateType.Click();
            this.Wait.Explicit(this.ExplicitTimeout);
            this.CertificateTypeList.Items.Where(i => i.TextContent == certificateType).FirstOrDefault().Click();
            this.SimulateRealTyping(this.FullnameInput, fullname);
            this.SimulateRealTyping(this.UsernameInput, username);
            this.UpdateButton.Click();

            this.Wait.Explicit(this.ExplicitTimeout);
        }

        public void AddNewCertificateWithoutCertificateType(string fullname, string username)
        {
            this.Wait.Explicit(this.ExplicitTimeout);
            bool usernameExists = this.CheckNameExistsInGrid(username, this.columnUsernameNumber);

            if (usernameExists && !string.IsNullOrEmpty(username))
            {
                this.DeleteGridRow(username, this.columnUsernameNumber);
                this.Wait.Explicit(this.ExplicitTimeout);
            }

            this.AddButton.Click();
            this.Wait.Explicit(this.ExplicitTimeout);
            this.SimulateRealTyping(this.FullnameInput, fullname);
            this.Wait.Explicit(this.ExplicitTimeout);
            this.SimulateRealTyping(this.UsernameInput, username);
            this.Wait.Explicit(this.ExplicitTimeout);
            this.UpdateButton.Click();

            this.Wait.Explicit(this.ExplicitTimeout);
        }
    }
}
