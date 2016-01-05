namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateTypesPage
{
    using System;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class CertificateTypesPage
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

        public HtmlSpan SelectCertificateTemplate
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByExpression<HtmlSpan>("aria-owns=CertificateTemplateId_listbox");
            }
        }

        public HtmlUnorderedList CertificateTemplateList
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlUnorderedList>("CertificateTemplateId_listbox");
            }
        }

        public HtmlDiv CertificateTemplateValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("CertificateTemplateId_validationMessage");
            }
        }
    }
}
