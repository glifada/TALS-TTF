namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CourseTracksPage
{
    using System.IO;
    using System.Linq;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class CourseTracksPageAsserter
    {
        private static readonly int ColumnNameBgNumber = 1;
        private static readonly int ColumnNameEnNumber = 2;
        private static readonly int ColumnUrlNameNumber = 3;
        private static readonly string NameBgValidationMessage = "Моля въведете име на професията на български";
        private static readonly string NameEnValidationMessage = "Моля въведете име на професията на английски";
        private static readonly string UrlNameValidationMessage = "Моля въведете URL име";

        public static void AssertAddedCourseTrackWithValidRequiredData(
            this CourseTracksPage courseTracksPage, string nameBg, string nameEn, string urlName)
        {
            Assert.AreEqual(nameBg, courseTracksPage.Grid
                .Rows.FirstOrDefault().Cells[ColumnNameBgNumber]
                .Find.AllByTagName<HtmlAnchor>("a").FirstOrDefault().TextContent);
            Assert.AreEqual(nameEn, courseTracksPage.Grid
                .Rows.FirstOrDefault().Cells[ColumnNameEnNumber].TextContent);
            Assert.AreEqual(urlName, courseTracksPage.Grid
                .Rows.FirstOrDefault().Cells[ColumnUrlNameNumber].TextContent);
        }

        public static void AssertAddCourseTrackWithoutNameInBulgarian(
            this CourseTracksPage courseTracksPage)
        {
            Assert.IsTrue(courseTracksPage.NameBgValidationMessage.IsVisible());
            Assert.AreEqual(NameBgValidationMessage, courseTracksPage.NameBgValidationMessage.TextContent);
        }

        public static void AssertAddCourseTrackWithoutNameInEnglish(
            this CourseTracksPage courseTracksPage)
        {
            Assert.IsTrue(courseTracksPage.NameEnValidationMessage.IsVisible());
            Assert.AreEqual(NameEnValidationMessage, courseTracksPage.NameEnValidationMessage.TextContent);
        }

        public static void AssertAddCourseTrackWithoutUrlName(
            this CourseTracksPage courseTracksPage)
        {
            Assert.IsTrue(courseTracksPage.UrlNameValidationMessage.IsVisible());
            Assert.AreEqual(UrlNameValidationMessage, courseTracksPage.UrlNameValidationMessage.TextContent);
        }

        public static void AssertReportExists(
            this CourseTracksPage courseTracksPage, string filePath)
        {
            Assert.IsTrue(File.Exists(filePath));
            FileInfo fileInfo = new FileInfo(filePath);
            Assert.IsTrue(fileInfo.Length > 0);
        }
    }
}
