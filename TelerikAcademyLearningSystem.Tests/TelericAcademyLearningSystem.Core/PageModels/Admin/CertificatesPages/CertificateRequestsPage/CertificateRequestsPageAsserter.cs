namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateRequestsPage
{
    using System.IO;
    using System.Linq;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class CertificateRequestsPageAsserter
    {
        private static readonly int ColumnNamesNumber = 1;
        private static readonly int ColumnUsernameNumber = 2;
        private static readonly int ColumnCourseTrackNumber = 4;
        private static readonly string CourseTrackValidationMessage = "Моля изберете специалност";
        private static readonly string UsernameValidationMessage = "Моля въведете потребителско име";
        private static readonly string UserFullnameValidationMessage = "Моля въведете пълно име на потребителя";

        public static void AssertAddedCertificateRequest(
            this CertificateRequestsPage certificateRequestsPage,
            string courseTrack, string username, string names)
        {
            Assert.AreEqual(names, certificateRequestsPage.Grid
                .Rows.FirstOrDefault().Cells[ColumnNamesNumber].TextContent);
            Assert.AreEqual(username, certificateRequestsPage.Grid
                .Rows.FirstOrDefault().Cells[ColumnUsernameNumber]
                .Find.AllByTagName<HtmlAnchor>("a").FirstOrDefault().TextContent);
            Assert.AreEqual(courseTrack, certificateRequestsPage.Grid
                .Rows.FirstOrDefault().Cells[ColumnCourseTrackNumber]
                .Find.AllByTagName<HtmlAnchor>("a").FirstOrDefault().TextContent);
        }

        public static void AssertAddCertificateRequestWithoutCourseTrack(
            this CertificateRequestsPage certificateRequestsPage)
        {
            Assert.IsTrue(certificateRequestsPage.CourseTrackValidationMessage.IsVisible());
            Assert.AreEqual(CourseTrackValidationMessage, certificateRequestsPage.CourseTrackValidationMessage.TextContent);
        }

        public static void AssertAddCertificateRequestWithoutUsername(
            this CertificateRequestsPage certificateRequestsPage)
        {
            Assert.IsTrue(certificateRequestsPage.UsernameValidationMessage.IsVisible());
            Assert.AreEqual(UsernameValidationMessage, certificateRequestsPage.UsernameValidationMessage.TextContent);
        }

        public static void AssertAddCertificateRequestWithoutUserFullname(
            this CertificateRequestsPage certificateRequestsPage)
        {
            Assert.IsTrue(certificateRequestsPage.UserFullnameValidationMessage.IsVisible());
            Assert.AreEqual(UserFullnameValidationMessage, certificateRequestsPage.UserFullnameValidationMessage.TextContent);
        }

        public static void AssertReportExists(
            this CertificateRequestsPage certificateRequestsPage, string filePath)
        {
            Assert.IsTrue(File.Exists(filePath));
            FileInfo fileInfo = new FileInfo(filePath);
            Assert.IsTrue(fileInfo.Length > 0);
        }
    }
}
