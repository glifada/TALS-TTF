namespace TelerikAcademyLearningSystem.Tests.Admin.CertificateTests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TelerikAcademy.Core.Attributes;
    using TelerikAcademy.Core.Globals;
    using TelerikAcademyLearningSystem.Core.PageModels.Admin.CertificatesPages.CertificateTypesPage;
    using TelerikAcademyLearningSystem.Tests.BaseTest;

    [TestClass]
    public class CertificateTypesTests : AcademyBaseTest
    {
        private const string TestCategory = TestSections.Admin + "/" + TestSections.Certificates;
        private readonly string name = "Тип на сертификата";
        private readonly string certificateTemplate = "Тестов шаблон";
        private readonly string excelReportPath = Directory.GetCurrentDirectory() + @"\report.xlsx";
        private readonly string pdfReportPath = Directory.GetCurrentDirectory() + @"\report.pdf";
        private CertificateTypesPage certificateTypesPage;

        [TestInitialize]
        public void TestInitialize()
        {
            this.certificateTypesPage = new CertificateTypesPage(this.Manager);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C67"),
        Owner(Owners.Galya)]
        public void AddNewCertificateTypeWithValidData()
        {
            this.certificateTypesPage.NavigateToPage();
            this.certificateTypesPage.AddNewCertificateType(this.name, this.certificateTemplate);
            this.certificateTypesPage.AssertAddedCertificateTypeWithValidData(this.name);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C68"),
        Owner(Owners.Galya)]
        public void AddNewCertificateTypeWithoutName()
        {
            this.certificateTypesPage.NavigateToPage();
            this.certificateTypesPage.AddNewCertificateType(string.Empty, this.certificateTemplate);
            this.certificateTypesPage.AssertAddCertificateTypeWithoutName();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C113"),
        Owner(Owners.Galya)]
        public void AddNewCertificateTypeWithoutTemplate()
        {
            this.certificateTypesPage.NavigateToPage();
            this.certificateTypesPage.AddNewCertificateTypeWithoutTemplate(this.name);
            this.certificateTypesPage.AssertAddCertificateTypeWithoutTemplate();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.Medium),
        TestCaseId("C69"),
        Owner(Owners.Galya)]
        public void DownloadExcelReportForCertificateTypes()
        {
            this.certificateTypesPage.NavigateToPage();
            this.certificateTypesPage.DownloadExcelReport(this.excelReportPath);
            this.certificateTypesPage.AssertReportExists(this.excelReportPath);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.Medium),
        TestCaseId("C70"),
        Owner(Owners.Galya)]
        public void DownloadPDFReportForCertificateTypes()
        {
            this.certificateTypesPage.NavigateToPage();
            this.certificateTypesPage.DownloadPDFReport(this.pdfReportPath);
            this.certificateTypesPage.AssertReportExists(this.pdfReportPath);
        }
    }
}
