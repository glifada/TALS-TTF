namespace TelerikAcademyLearningSystem.Core.Facades.Admin.Certificates
{
    using System;

    using TelerikAcademyLearningSystem.Core.PageModels.Admin.CourseTracksPage;

    public class CourseTracksFacade
    {
        private readonly CourseTracksPage courseTracksPage;

        public CourseTracksFacade(CourseTracksPage courseTracksPage)
        {
            this.courseTracksPage = courseTracksPage;
        }
    }
}
