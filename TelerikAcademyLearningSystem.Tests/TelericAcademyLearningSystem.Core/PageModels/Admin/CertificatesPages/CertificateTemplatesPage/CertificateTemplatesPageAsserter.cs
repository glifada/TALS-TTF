namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateTemplatesPage
{
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class CertificateTemplatesPageAsserter
    {
        private static readonly int ColumnNameNumber = 2;
        private static readonly string NameValidationMessage  = "Моля въведете име на шаблона";

        public static void AssertAddedCertificateTemplateWithValidName(
            this CertificateTemplatesPage certificateTemplatesPage,
            string name)
        {
            Assert.AreEqual(name, certificateTemplatesPage.Grid.Rows.FirstOrDefault().Cells[ColumnNameNumber].TextContent);
        }

        public static void AssertAddCertificateTemplateWithoutName(
            this CertificateTemplatesPage certificateTemplatesPage)
        {
            Assert.IsTrue(certificateTemplatesPage.NameValidationMessage.IsVisible());
            Assert.AreEqual(NameValidationMessage, certificateTemplatesPage.NameValidationMessage.TextContent);
        }

        public static void AssertReportExists(
            this CertificateTemplatesPage certificateTemplatesPage, string filePath)
        {
            Assert.IsTrue(File.Exists(filePath));
            FileInfo fileInfo = new FileInfo(filePath);
            Assert.IsTrue(fileInfo.Length > 0);
        }
    }
}
