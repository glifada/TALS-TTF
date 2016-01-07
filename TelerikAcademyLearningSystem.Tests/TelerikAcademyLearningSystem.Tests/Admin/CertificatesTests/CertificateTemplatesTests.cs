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
        Priority(TestPriorities.High),
        TestCaseId("C73"),
        Owner(Owners.Galya)]
        public void AddNewCertificateTemplateWithValidName()
        {
            this.certificateTemplatePage.NavigateToPage();
            this.certificateTemplatePage.AddCertificateTemplate(this.name);
            this.certificateTemplatePage.AssertAddedCertificateTemplateWithValidName(this.name);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C74"),
        Owner(Owners.Galya)]
        public void AddNewCertificateTemplateWithoutName()
        {
            this.certificateTemplatePage.NavigateToPage();
            this.certificateTemplatePage.AddCertificateTemplate(string.Empty);
            this.certificateTemplatePage.AssertAddCertificateTemplateWithoutName();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.Medium),
        TestCaseId("C75"),
        Owner(Owners.Galya)]
        public void DownloadExcelReportForCourseTracks()
        {
            this.certificateTemplatePage.NavigateToPage();
            this.certificateTemplatePage.DownloadExcelReport(this.excelReportPath);
            this.certificateTemplatePage.AssertReportExists(this.excelReportPath);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.Medium),
        TestCaseId("C76"),
        Owner(Owners.Galya)]
        public void DownloadPDFReportForCourseTracks()
        {
            this.certificateTemplatePage.NavigateToPage();
            this.certificateTemplatePage.DownloadPDFReport(this.pdfReportPath);
            this.certificateTemplatePage.AssertReportExists(this.pdfReportPath);
        }
    }
}
