namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateTypesPage
{
    using System;
    using System.Linq;
    using System.Threading;
    using ArtOfTest.WebAii.Core;

    public partial class CertificateTypesPage : AdminPage
    {
        private readonly int columnNameNumber = 1;

        public CertificateTypesPage(Manager manager)
            : base(manager)
        {
            this.PageUrl = "http://stage.telerikacademy.com/Administration_Certificates/CertificateTypes";
        }

        public void AddNewCertificateType(string name, string certificateTemplate)
        {
            bool nameExists = this.CheckNameExistsInGrid(name, this.columnNameNumber);

            if (nameExists && !string.IsNullOrEmpty(name))
            {
                this.DeleteGridRow(name, this.columnNameNumber);
                this.Wait.Explicit(this.ExplicitTimeout);
            }

            this.AddButton.Click();
            this.SimulateRealTyping(this.NameInput, name);
            this.SelectCertificateTemplate.Click();
            this.Wait.Explicit(this.ExplicitTimeout);
            this.CertificateTemplateList.Items.Where(i => i.TextContent == certificateTemplate).FirstOrDefault().Click();
            this.UpdateButton.Click();

            this.Wait.Explicit(this.ExplicitTimeout);
        }

        public void AddNewCertificateTypeWithoutTemplate(string name)
        {
            bool nameExists = this.CheckNameExistsInGrid(name, this.columnNameNumber);

            if (nameExists)
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
