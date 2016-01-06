namespace TelerikAcademyLearningSystem.Tests.Admin.CertificateTests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TelerikAcademy.Core.Attributes;
    using TelerikAcademy.Core.Globals;
    using TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateRequestsPage;
    using TelerikAcademyLearningSystem.Tests.BaseTest;

    [TestClass]
    public class CertificateRequestsTest : AcademyBaseTest
    {
        private const string TestCategory = TestSections.Admin + "/" + TestSections.Certificates;
        private const string OwnerName = "Galya";
        private readonly string courseTrack = "QA Инженер";
        private readonly string username = "unicorn";
        private readonly string userFullname = "Иван Иванов Иванов";
        private readonly string excelReportPath = Directory.GetCurrentDirectory() + @"\report.xlsx";
        private readonly string pdfReportPath = Directory.GetCurrentDirectory() + @"\report.pdf";
        private CertificateRequestsPage certificateRequestsPage;

        [TestInitialize]
        public void TestInitialize()
        {
            this.certificateRequestsPage = new CertificateRequestsPage(this.Manager);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(2),
        TestCaseId("C61"),
        Owner(OwnerName)]
        public void AddNewCertificateRequestWithValidRequiredData()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.AddNewCertificateRequest(this.courseTrack, this.username, this.userFullname);
            this.certificateRequestsPage.AssertAddedCertificateRequest(this.courseTrack, this.username, this.userFullname);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(2),
        TestCaseId("C62"),
        Owner(OwnerName)]
        public void AddNewCertificateRequestWithoutCourseTrack()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.AddNewCertificateRequestWithoutCourseTrack(this.username, this.userFullname);
            this.certificateRequestsPage.AssertAddCertificateRequestWithoutCourseTrack();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(2),
        TestCaseId("C114"),
        Owner(OwnerName)]
        public void AddNewCertificateRequestWithoutUsername()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.AddNewCertificateRequest(this.courseTrack, string.Empty, this.userFullname);
            this.certificateRequestsPage.AssertAddCertificateRequestWithoutUsername();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(2),
        TestCaseId("C115"),
        Owner(OwnerName)]
        public void AddNewCertificateRequestWithoutUserFullname()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.AddNewCertificateRequest(this.courseTrack, this.username, string.Empty);
            this.certificateRequestsPage.AssertAddCertificateRequestWithoutUserFullname();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(3),
        TestCaseId("C63"),
        Owner(OwnerName)]
        public void DownloadExcelReportForCourseTracks()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.DownloadExcelReport(this.excelReportPath);
            this.certificateRequestsPage.AssertReportExists(this.excelReportPath);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(3),
        TestCaseId("C64"),
        Owner(OwnerName)]
        public void DownloadPDFReportForCourseTracks()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.DownloadPDFReport(this.pdfReportPath);
            this.certificateRequestsPage.AssertReportExists(this.pdfReportPath);
        }
    }
}
