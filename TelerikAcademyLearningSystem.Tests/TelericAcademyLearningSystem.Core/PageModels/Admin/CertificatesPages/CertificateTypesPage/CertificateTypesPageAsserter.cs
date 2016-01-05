namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateTypesPage
{
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class CertificateTypesPageAsserter
    {
        private static readonly int ColumnNameNumber = 1;
        private static readonly string NameValidationMessage = "Моля въведете име за типа на сертификата";
        private static readonly string CertificateTemplateValidationMessage = "Моля изберете шаблон за сертификата";

        public static void AssertAddedCertificateTypeWithValidData(
            this CertificateTypesPage certificateTypesPage,
            string name)
        {
            Assert.AreEqual(name, certificateTypesPage.Grid.Rows.FirstOrDefault().Cells[ColumnNameNumber].TextContent);
        }

        public static void AssertAddCertificateTypeWithoutName(
            this CertificateTypesPage certificateTypesPage)
        {
            Assert.IsTrue(certificateTypesPage.NameValidationMessage.IsVisible());
            Assert.AreEqual(NameValidationMessage, certificateTypesPage.NameValidationMessage.TextContent);
        }

        public static void AssertAddCertificateTypeWithoutTemplate(
            this CertificateTypesPage certificateTypesPage)
        {
            Assert.IsTrue(certificateTypesPage.CertificateTemplateValidationMessage.IsVisible());
            Assert.AreEqual(CertificateTemplateValidationMessage, certificateTypesPage.CertificateTemplateValidationMessage.TextContent);
        }

        public static void AssertReportExists(
            this CertificateTypesPage certificateTypesPage,
            string filePath)
        {
            Assert.IsTrue(File.Exists(filePath));
            FileInfo fileInfo = new FileInfo(filePath);
            Assert.IsTrue(fileInfo.Length > 0);
        }
    }
}
