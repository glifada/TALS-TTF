namespace TelerikAcademyLearningSystem.Core.PageModels.Base
{
    using System.Windows.Forms;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;

    public abstract class BasePage
    {
        public readonly int WaitForElementTimeout = 3000;
        public readonly int ExplicitTimeout = 500;
        private const int SimulateRealTypingDelay = 10;
        private readonly Manager manager;
        private readonly BrowserWait wait;

        public BasePage(Manager manager)
        {
            this.manager = manager;
            this.wait = new BrowserWait(this.Manager);
        }

        public Manager Manager
        {
            get
            {
                return this.manager;
            }
        }

        /// <summary>
        /// Wait for page elements to load. Accepts an int for milliseconds.
        /// Gives access to two Methods: Explcit(int time) and Implicit(int time)
        /// </summary>
        /// <param name="time">Set the time in milliseconds to wait</param>
        public BrowserWait Wait
        {
            get
            {
                return this.wait;
            }
        }

        public string PageUrl { get; set; }

        /// <summary>
        /// Simulate real typing by double clicking on the element and typing with the keyboard. Accepts html control, text and delay in milliseconds.
        /// </summary>
        /// <param name="control">Html control to type in</param>
        /// <param name="text">Text to type</param>
        /// <param name="delay">Delay between key strokes</param>
        public void SimulateRealTyping(HtmlControl control, string text, int delay = SimulateRealTypingDelay)
        {
            this.manager.ActiveBrowser.Window.SetFocus();
            control.Focus();
            control.MouseClick();
            control.MouseClick();
            this.manager.Desktop.KeyBoard.TypeText(text, delay);
            this.manager.Desktop.KeyBoard.KeyPress(Keys.Enter, delay);
        }

        /// <summary>
        /// Navigates to this page
        /// </summary>
        public void NavigateToPage()
        {
            this.Manager.ActiveBrowser.NavigateTo(this.PageUrl);
            this.Wait.Explicit(this.ExplicitTimeout);
        }
    }
}
