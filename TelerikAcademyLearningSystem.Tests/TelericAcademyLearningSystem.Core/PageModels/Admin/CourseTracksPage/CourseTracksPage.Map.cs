namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CourseTracksPage
{
    using System;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class CourseTracksPage
    {
        public HtmlInputText NameBgInput
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlInputText>("NameBg");
            }
        }

        public HtmlDiv NameBgValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("NameBg_validationMessage");
            }
        }

        public HtmlInputText NameEnInput
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlInputText>("NameEn");
            }
        }

        public HtmlDiv NameEnValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("NameEn_validationMessage");
            }
        }

        public HtmlInputText UrlNameInput
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlInputText>("UrlName");
            }
        }

        public HtmlDiv UrlNameValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("UrlName_validationMessage");
            }
        }
    }
}
