namespace TelerikAcademyLearningSystem.Core.PageModels.Admin.CourseTracksPage
{
    using System;
    using System.Threading;
    using ArtOfTest.WebAii.Core;

    public partial class CourseTracksPage : AdminPage
    {
        private readonly int columnNameNumber = 1;

        public CourseTracksPage(Manager manager)
            : base(manager)
        {
            this.PageUrl = "http://stage.telerikacademy.com/Administration_Courses/CourseTracks";
        }

        public void AddCourseTrack(string nameBg, string nameEn, string urlName)
        {
            bool nameExists = this.CheckNameExistsInGrid(nameBg, this.columnNameNumber);

            if (nameExists && !string.IsNullOrEmpty(nameBg))
            {
                this.DeleteGridRow(nameBg, this.columnNameNumber);
                this.Wait.Explicit(this.ExplicitTimeout);
            }

            this.AddButton.Click();
            this.SimulateRealTyping(this.NameBgInput, nameBg);
            this.SimulateRealTyping(this.NameEnInput, nameEn);
            this.SimulateRealTyping(this.UrlNameInput, urlName);
            this.UpdateButton.Click();

            this.Wait.Explicit(this.ExplicitTimeout);
        }
    }
}
