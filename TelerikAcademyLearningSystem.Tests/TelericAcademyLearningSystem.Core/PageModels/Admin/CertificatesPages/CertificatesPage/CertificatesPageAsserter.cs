namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificatesPage
{
    using System.IO;
    using System.Linq;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class CertificatesPageAsserter
    {
        private static readonly int ColumnNamesNumber = 2;
        private static readonly int ColumnUsernameNumber = 3;
        private static readonly int ColumnCertificateTypeNumber = 5;
        private static readonly string CertificateTypeValidationMessage = "Моля изберете тип за сертификата";
        private static readonly string FullnameValidationMessage = "Моля въведете пълно име на потребителя";
        private static readonly string UsernameValidationMessage = "Моля въведете потребителско име";

        public static void AssertAddedCertificate(
            this CertificatesPage certificatesPage,
            string certificateType, string fullname, string username)
        {
            Assert.AreEqual(fullname, certificatesPage.Grid
                .Rows.FirstOrDefault().Cells[ColumnNamesNumber].TextContent);
            Assert.AreEqual(username, certificatesPage.Grid
                .Rows.FirstOrDefault().Cells[ColumnUsernameNumber].TextContent);
            Assert.AreEqual(certificateType, certificatesPage.Grid
                .Rows.FirstOrDefault().Cells[ColumnCertificateTypeNumber].TextContent);
        }

        public static void AssertAddCertificateWithoutCertificateType(
            this CertificatesPage certificatesPage)
        {
            Assert.IsTrue(certificatesPage.CertificateTypeValidationMessage.IsVisible());
            Assert.AreEqual(CertificateTypeValidationMessage, certificatesPage.CertificateTypeValidationMessage.TextContent);
        }

        public static void AssertAddCertificateWithoutFullname(
            this CertificatesPage certificatesPage)
        {
            Assert.IsTrue(certificatesPage.FullnameValidationMessage.IsVisible());
            Assert.AreEqual(FullnameValidationMessage, certificatesPage.FullnameValidationMessage.TextContent);
        }

        public static void AssertAddCertificateWithoutUsername(
            this CertificatesPage certificatesPage)
        {
            Assert.IsTrue(certificatesPage.UsernameValidationMessage.IsVisible());
            Assert.AreEqual(UsernameValidationMessage, certificatesPage.UsernameValidationMessage.TextContent);
        }

        public static void AssertReportExists(
           this CertificatesPage certificatesPage, string filePath)
        {
            Assert.IsTrue(File.Exists(filePath));
            FileInfo fileInfo = new FileInfo(filePath);
            Assert.IsTrue(fileInfo.Length > 0);
        }
    }
}
