namespace TelerikAcademyLearningSystem.Tests.Admin.CertificateTests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TelerikAcademy.Core.Attributes;
    using TelerikAcademy.Core.Globals;
    using TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateTemplatesPage;
    using TelerikAcademyLearningSystem.Tests.BaseTest;

    [TestClass]
    public class CertificateTemplatesTests : AcademyBaseTest
    {
        private const string TestCategory = TestSections.Admin + "/" + TestSections.Certificates;
        private const string OwnerName = "Galya";
        private readonly string name = "Тестов шаблон";
        private readonly string excelReportPath = Directory.GetCurrentDirectory() + @"\report.xlsx";
        private readonly string pdfReportPath = Directory.GetCurrentDirectory() + @"\report.pdf";
        private CertificateTemplatesPage certificateTemplatePage;

        [TestInitialize]
        public void TestInitialize()
        {
            this.certificateTemplatePage = new CertificateTemplatesPage(this.Manager);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(2),
        TestCaseId("C73"),
        Owner(OwnerName)]
        public void AddNewCertificateTemplateWithValidName()
        {
            this.certificateTemplatePage.NavigateToPage();
            this.certificateTemplatePage.AddCertificateTemplate(this.name);
            this.certificateTemplatePage.AssertAddedCertificateTemplateWithValidName(this.name);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(2),
        TestCaseId("C74"),
        Owner(OwnerName)]
        public void AddNewCertificateTemplateWithoutName()
        {
            this.certificateTemplatePage.NavigateToPage();
            this.certificateTemplatePage.AddCertificateTemplate(string.Empty);
            this.certificateTemplatePage.AssertAddCertificateTemplateWithoutName();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(3),
        TestCaseId("C75"),
        Owner(OwnerName)]
        public void DownloadExcelReportForCourseTracks()
        {
            this.certificateTemplatePage.NavigateToPage();
            this.certificateTemplatePage.DownloadExcelReport(this.excelReportPath);
            this.certificateTemplatePage.AssertReportExists(this.excelReportPath);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(3),
        TestCaseId("C76"),
        Owner(OwnerName)]
        public void DownloadPDFReportForCourseTracks()
        {
            this.certificateTemplatePage.NavigateToPage();
            this.certificateTemplatePage.DownloadPDFReport(this.pdfReportPath);
            this.certificateTemplatePage.AssertReportExists(this.pdfReportPath);
        }
    }
}
