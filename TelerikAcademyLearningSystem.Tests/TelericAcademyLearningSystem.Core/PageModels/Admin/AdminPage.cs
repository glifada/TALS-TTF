namespace TelerikAcademyLearningSystem.Core.PageModels.Admin
{
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;

    using TelerikAcademyLearningSystem.Core.PageModels.Base;

    public partial class AdminPage : BasePage
    {
        private readonly int WaitUntilHandledTimeout = 30000;

        public AdminPage(Manager manager)
            : base(manager)
        {
        }

        public bool CheckNameExistsInGrid(string name, int columnNumber)
        {
            return this.Grid.Rows.Any(row => row.Cells[columnNumber].InnerText.Contains(name));
        }

        public void DeleteGridRow(string rowName, int columnNumber)
        {
            var containedRow = this.Grid.Rows.FirstOrDefault(row => row.Cells[columnNumber].InnerText.Contains(rowName));
            var deleteBtn = containedRow.Find.ByExpression<HtmlAnchor>("class=k-button k-button-icontext k-grid-delete");
            deleteBtn.Click();
            this.Manager.ActiveBrowser.WaitUntilReady();
            Manager.Desktop.KeyBoard.KeyPress(Keys.Enter, 10);
            this.Manager.ActiveBrowser.WaitUntilReady();
        }

        public void DownloadExcelReport(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                this.Wait.Explicit(this.ExplicitTimeout);
            }

            DownloadDialogsHandler dialog = new DownloadDialogsHandler(Manager.ActiveBrowser, DialogButton.SAVE, filePath, Manager.Desktop);
            Manager.DialogMonitor.Start();
            this.DownloadExcelButton.Click();
            dialog.WaitUntilHandled(this.WaitUntilHandledTimeout);
        }

        public void DownloadPDFReport(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                this.Wait.Explicit(this.ExplicitTimeout);
            }

            DownloadDialogsHandler dialog = new DownloadDialogsHandler(Manager.ActiveBrowser, DialogButton.SAVE, filePath, Manager.Desktop);
            Manager.DialogMonitor.Start();
            this.DownloadPDFButton.Click();
            dialog.WaitUntilHandled(this.WaitUntilHandledTimeout);
        }
    }
}
