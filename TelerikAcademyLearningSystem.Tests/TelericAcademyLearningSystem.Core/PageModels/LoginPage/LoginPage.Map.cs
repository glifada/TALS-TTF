namespace TelerikAcademyLearningSystem.Core.PageModels.LoginPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    public partial class LoginPage
    {
        public HtmlInputText Username
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlInputText>("UsernameOrEmail");
            }
        }

        public HtmlInputPassword Password
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlInputPassword>("Password");
            }
        }

        public HtmlInputSubmit Submit
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByAttributes<HtmlInputSubmit>("value=Вход");
            }
        }

        public HtmlAnchor LoggedUser
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("/html/body/div[1]/header/div/div[1]/a[1]");
            }
        }

        public HtmlAnchor Logout
        {
            get
            {
                return this.Manager.ActiveBrowser.Find.ById<HtmlAnchor>("ExitMI");
            }
        }
    }
}
