namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateTemplatesPage
{
    using System;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class CertificateTemplatesPage
    {
        public HtmlInputText NameInput
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlInputText>("Name");
            }
        }

        public HtmlDiv NameValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("Name_validationMessage");
            }
        }
    }
}
