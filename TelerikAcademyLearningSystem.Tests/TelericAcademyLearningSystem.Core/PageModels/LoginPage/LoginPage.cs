namespace TelerikAcademyLearningSystem.Core.PageModels.LoginPage
{
    using ArtOfTest.WebAii.Core;

    using TelerikAcademyLearningSystem.Core.PageModels.Base;

    public partial class LoginPage : BasePage
    {
        public LoginPage(Manager manager)
            : base(manager)
        {
            this.PageUrl = "http://stage.telerikacademy.com/Users/Auth/Login";
        }

        public void LogAsAdmin()
        {
            this.Login("unicorn", "test123");
        }

        public void Login(string username, string password)
        {
            this.Manager.ActiveBrowser.WaitUntilReady();
            this.Manager.ActiveBrowser.WaitForElement(new HtmlFindExpression("id=?Panel"), this.WaitForElementTimeout, false);

            if (this.LoggedUser.TextContent == "Вход")
            {
                this.Username.Text = username;
                this.Password.Text = password;
                this.Submit.Click();
            }
            else if (this.LoggedUser.TextContent != "Вход" && this.LoggedUser.TextContent != username)
            {
                this.Logout.Click();
                this.NavigateToPage();
                this.Login(username, password);
            }
        }
    }
}
