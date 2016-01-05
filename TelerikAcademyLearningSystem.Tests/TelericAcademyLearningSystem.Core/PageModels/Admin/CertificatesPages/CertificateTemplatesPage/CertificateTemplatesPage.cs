namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateTemplatesPage
{
    using System;
    using System.Threading;
    using ArtOfTest.WebAii.Core;

    public partial class CertificateTemplatesPage : AdminPage
    {
        private readonly int columnNameNumber = 2;

        public CertificateTemplatesPage(Manager manager)
            : base(manager)
        {
            this.PageUrl = "http://stage.telerikacademy.com/Administration_Certificates/CertificateTemplates";
        }

        public void AddCertificateTemplate(string name)
        {
            bool nameExists = this.CheckNameExistsInGrid(name, this.columnNameNumber);

            if (nameExists && !string.IsNullOrEmpty(name))
            {
                this.DeleteGridRow(name, this.columnNameNumber);
                this.Wait.Explicit(this.ExplicitTimeout);
            }

            this.AddButton.Click();
            this.SimulateRealTyping(this.NameInput, name);
            this.UpdateButton.Click();

            this.Wait.Explicit(this.ExplicitTimeout);
        }
    }
}
