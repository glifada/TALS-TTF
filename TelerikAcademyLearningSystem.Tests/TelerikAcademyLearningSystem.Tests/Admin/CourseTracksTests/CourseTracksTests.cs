namespace TelerikAcademyLearningSystem.Tests.Admin.CourseTrackTests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TelerikAcademy.Core.Attributes;
    using TelerikAcademy.Core.Globals;
    using TelerikAcademyLearningSystem.Core.PageModels.Admin.CourseTracksPage;
    using TelerikAcademyLearningSystem.Tests.BaseTest;

    [TestClass]
    public class CourseTrackTests : AcademyBaseTest
    {
        private const string TestCategory = TestSections.Admin + "/" + TestSections.Tracks;
        private readonly string nameBg = "QA инженер1";
        private readonly string nameEn = "QA engineer1";
        private readonly string urlName = "quality-assurance-engineer";
        private readonly string excelReportPath = Directory.GetCurrentDirectory() + @"\report.xlsx";
        private readonly string pdfReportPath = Directory.GetCurrentDirectory() + @"\report.pdf";
        private CourseTracksPage courseTrackPage;

        [TestInitialize]
        public void TestInitialize()
        {
            this.courseTrackPage = new CourseTracksPage(this.Manager);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C49"),
        Owner(Owners.Galya)]
        public void AddCourseTrackWithValidRequiredData()
        {
            this.courseTrackPage.NavigateToPage();
            this.courseTrackPage.AddCourseTrack(this.nameBg, this.nameEn, this.urlName);
            this.courseTrackPage.AssertAddedCourseTrackWithValidRequiredData(this.nameBg, this.nameEn, this.urlName);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C50"),
        Owner(Owners.Galya)]
        public void AddCourseTrackWithoutNameInBulgarian()
        {
            this.courseTrackPage.NavigateToPage();
            this.courseTrackPage.AddCourseTrack(string.Empty, this.nameEn, this.urlName);
            this.courseTrackPage.AssertAddCourseTrackWithoutNameInBulgarian();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C111"),
        Owner(Owners.Galya)]
        public void AddCourseTrackWithoutNameInEnglish()
        {
            this.courseTrackPage.NavigateToPage();
            this.courseTrackPage.AddCourseTrack(this.nameBg, string.Empty, this.urlName);
            this.courseTrackPage.AssertAddCourseTrackWithoutNameInEnglish();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.High),
        TestCaseId("C112"),
        Owner(Owners.Galya)]
        public void AddCourseTrackWithoutUrlName()
        {
            this.courseTrackPage.NavigateToPage();
            this.courseTrackPage.AddCourseTrack(this.nameBg, this.nameEn, string.Empty);
            this.courseTrackPage.AssertAddCourseTrackWithoutUrlName();
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.Medium),
        TestCaseId("C27"),
        Owner(Owners.Galya)]
        public void DownloadExcelReportForCourseTracks()
        {
            this.courseTrackPage.NavigateToPage();
            this.courseTrackPage.DownloadExcelReport(this.excelReportPath);
            this.courseTrackPage.AssertReportExists(this.excelReportPath);
        }

        [TestMethod,
        TestCategory(TestCategory),
        Priority(TestPriorities.Medium),
        TestCaseId("C28"),
        Owner(Owners.Galya)]
        public void DownloadPDFReportForCourseTracks()
        {
            this.courseTrackPage.NavigateToPage();
            this.courseTrackPage.DownloadPDFReport(this.pdfReportPath);
            this.courseTrackPage.AssertReportExists(this.pdfReportPath);
        }
    }
}
