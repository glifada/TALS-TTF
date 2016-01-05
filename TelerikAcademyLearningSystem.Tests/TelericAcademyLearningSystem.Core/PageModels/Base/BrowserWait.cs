namespace TelerikAcademyLearningSystem.Core.PageModels.Base
{
    using System.Threading;
    using ArtOfTest.WebAii.Core;

    public class BrowserWait
    {
        private readonly Manager manager;

        internal BrowserWait(Manager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Sets a time in milliseconds for the manager to wait, refreshed DOM tree.
        /// Good for slick controls like kendo dropdowns that take a set amount of time go expand.
        /// </summary>
        /// <param name="time">time in milliseconds to wait</param>
        public void Explicit(int time)
        {
            Thread.Sleep(time);
            this.manager.ActiveBrowser.WaitUntilReady();
            this.manager.ActiveBrowser.RefreshDomTree();
        }

        /// <summary>
        /// Sets a maximum time in milliseconds for the manager to wait for the page to load.
        /// Uses the page footer image as a reference.
        /// </summary>
        /// <param name="time"></param>
        public void Implicit(int time)
        {
            this.manager.ActiveBrowser.WaitUntilReady();

            var siteFooter = new HtmlFindExpression("id=FooterLogo");
            this.manager.ActiveBrowser.WaitForElement(siteFooter, time, false);
        }
    }
}
