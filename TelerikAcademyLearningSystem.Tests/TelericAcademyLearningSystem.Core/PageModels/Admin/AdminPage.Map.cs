namespace TelerikAcademyLearningSystem.Core.PageModels.Admin
{
    using System;
    using System.Linq;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class AdminPage
    {
        public HtmlAnchor AddButton
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("Добавяне");
            }
        }

        public HtmlButton DownloadExcelButton
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByContent<HtmlButton>("Сваляне на Excel");
            }
        }

        public HtmlButton DownloadPDFButton
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByContent<HtmlButton>("Сваляне на PDF");
            }
        }

        public HtmlAnchor BackToAdminButton
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("Към администрацията");
            }
        }

        public HtmlTable Grid
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByExpression<HtmlTable>("role=~grid");
            }
        }

        public HtmlAnchor UpdateButton
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("Update");
            }
        }
    }
}
