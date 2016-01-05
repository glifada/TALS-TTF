namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateRequestsPage
{
    using System;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class CertificateRequestsPage
    {
        public HtmlSpan SelectCourseTrack
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByExpression<HtmlSpan>("aria-owns=CourseTrackId_listbox");
            }
        }

        public HtmlUnorderedList CourseTrackList
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlUnorderedList>("CourseTrackId_listbox");
            }
        }

        public HtmlDiv CourseTrackValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("CourseTrackId_validationMessage");
            }
        }

        public HtmlInputText UsernameInput
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlInputText>("Username");
            }
        }

        public HtmlDiv UsernameValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("Username_validationMessage");
            }
        }

        public HtmlInputText UserFullnameInput
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlInputText>("UserFullname");
            }
        }

        public HtmlDiv UserFullnameValidationMessage
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlDiv>("UserFullname_validationMessage");
            }
        }
    }
}
