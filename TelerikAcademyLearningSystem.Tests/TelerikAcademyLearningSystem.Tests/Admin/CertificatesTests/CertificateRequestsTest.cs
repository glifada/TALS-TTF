﻿namespace TelerikAcademyLearningSystem.Tests.Admin.CertificateTests
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
        Priority(TestPriorities.High),
        TestCaseId("C61"),
        Owner(Owners.Galya)]
        public void AddNewCertificateRequestWithValidRequiredData()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.AddNewCertificateRequest(this.courseTrack, this.username, this.userFullname);
            this.certificateRequestsPage.AssertAddedCertificateRequest(this.courseTrack, this.username, this.userFullname);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C62"),
        Owner(Owners.Galya)]
        public void AddNewCertificateRequestWithoutCourseTrack()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.AddNewCertificateRequestWithoutCourseTrack(this.username, this.userFullname);
            this.certificateRequestsPage.AssertAddCertificateRequestWithoutCourseTrack();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C114"),
        Owner(Owners.Galya)]
        public void AddNewCertificateRequestWithoutUsername()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.AddNewCertificateRequest(this.courseTrack, string.Empty, this.userFullname);
            this.certificateRequestsPage.AssertAddCertificateRequestWithoutUsername();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C115"),
        Owner(Owners.Galya)]
        public void AddNewCertificateRequestWithoutUserFullname()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.AddNewCertificateRequest(this.courseTrack, this.username, string.Empty);
            this.certificateRequestsPage.AssertAddCertificateRequestWithoutUserFullname();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.Medium),
        TestCaseId("C63"),
        Owner(Owners.Galya)]
        public void DownloadExcelReportForCourseTracks()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.DownloadExcelReport(this.excelReportPath);
            this.certificateRequestsPage.AssertReportExists(this.excelReportPath);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.Medium),
        TestCaseId("C64"),
        Owner(Owners.Galya)]
        public void DownloadPDFReportForCourseTracks()
        {
            this.certificateRequestsPage.NavigateToPage();
            this.certificateRequestsPage.DownloadPDFReport(this.pdfReportPath);
            this.certificateRequestsPage.AssertReportExists(this.pdfReportPath);
        }
    }
}
