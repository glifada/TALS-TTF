namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificatesPage
{
    using System;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class CertificatesPage
    {
        public HtmlSpan SelectCertificateType
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByExpression<HtmlSpan>("aria-owns=CertificateTypeId_listbox");
            }
        }

        public HtmlUnorderedList CertificateTypeList
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlUnorderedList>("CertificateTypeId_listbox");
            }
        }

        public HtmlDiv CertificateTypeValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("CertificateTypeId_validationMessage");
            }
        }

        public HtmlInputText FullnameInput
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlInputText>("FullName");
            }
        }

        public HtmlDiv FullnameValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("FullName_validationMessage");
            }
        }

        public HtmlInputText UsernameInput
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlInputText>("CertifiedUserUsername");
            }
        }

        public HtmlDiv UsernameValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("CertifiedUserUsername_validationMessage");
            }
        }
    }
}
