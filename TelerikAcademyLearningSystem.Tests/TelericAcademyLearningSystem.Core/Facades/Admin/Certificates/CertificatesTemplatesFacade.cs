namespace TelerikAcademyLearningSystem.Core.Facades.Admin.Certificates
{
    using System;
    
    using TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateTemplatesPage;

    public class CertificatesFacade
    {
        private readonly CertificateTemplatesPage certificateTemplatePage;

        public CertificatesFacade(CertificateTemplatesPage certificateTemplatePage)
        {
            this.certificateTemplatePage = certificateTemplatePage;
        }

        public CertificateTemplatesPage CertificateTemplatePage
        {
            get
            {
                return this.certificateTemplatePage;
            }
        }

        public void AddNewCertificateTemplate(string name)
        {
            this.certificateTemplatePage.NavigateToPage();
            this.certificateTemplatePage.AddButton.Click();
            this.certificateTemplatePage.NameInput.Text = name;
            this.certificateTemplatePage.UpdateButton.Click();
        }
    }
}
