﻿namespace TelerikAcademyLearningSystem.Tests.Admin.CertificateTests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TelerikAcademy.Core.Attributes;
    using TelerikAcademy.Core.Globals;
    using TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificatesPage;
    using TelerikAcademyLearningSystem.Tests.BaseTest;

    [TestClass]
    public class CertificatesTests : AcademyBaseTest
    {
        private const string TestCategory = TestSections.Admin + "/" + TestSections.Certificates;
        private readonly string certificateType = "Тип на сертификата";
        private readonly string fullname = "Иван Иванов Иванов";
        private readonly string username = "unicorn";
        private readonly string excelReportPath = Directory.GetCurrentDirectory() + @"\report.xlsx";
        private readonly string pdfReportPath = Directory.GetCurrentDirectory() + @"\report.pdf";
        private CertificatesPage certificatesPage;

        [TestInitialize]
        public void TestInitialize()
        {
            this.certificatesPage = new CertificatesPage(this.Manager);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C55"),
        Owner(Owners.Galya)]
        public void AddNewCertificateWithValidRequiredData()
        {
            this.certificatesPage.NavigateToPage();
            this.certificatesPage.AddNewCertificate(this.certificateType, this.fullname, this.username);
            this.certificatesPage.AssertAddedCertificate(this.certificateType, this.fullname, this.username);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C56"),
        Owner(Owners.Galya)]
        public void AddNewCertificateWithoutCertificateType()
        {
            this.certificatesPage.NavigateToPage();
            this.certificatesPage.AddNewCertificateWithoutCertificateType(this.fullname, this.username);
            this.certificatesPage.AssertAddCertificateWithoutCertificateType();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C116"),
        Owner(Owners.Galya)]
        public void AddNewCertificateWithoutFullname()
        {
            this.certificatesPage.NavigateToPage();
            this.certificatesPage.AddNewCertificate(this.certificateType, string.Empty, this.username);
            this.certificatesPage.AssertAddCertificateWithoutFullname();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C117"),
        Owner(Owners.Galya)]
        public void AddNewCertificateWithoutUserName()
        {
            this.certificatesPage.NavigateToPage();
            this.certificatesPage.AddNewCertificate(this.certificateType, this.fullname, string.Empty);
            this.certificatesPage.AssertAddCertificateWithoutUsername();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.Medium),
        TestCaseId("C57"),
        Owner(Owners.Galya)]
        public void DownloadExcelReportForCourseTracks()
        {
            this.certificatesPage.NavigateToPage();
            this.certificatesPage.DownloadExcelReport(this.excelReportPath);
            this.certificatesPage.AssertReportExists(this.excelReportPath);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.Medium),
        TestCaseId("C58"),
        Owner(Owners.Galya)]
        public void DownloadPDFReportForCourseTracks()
        {
            this.certificatesPage.NavigateToPage();
            this.certificatesPage.DownloadPDFReport(this.pdfReportPath);
            this.certificatesPage.AssertReportExists(this.pdfReportPath);
        }
    }
}
