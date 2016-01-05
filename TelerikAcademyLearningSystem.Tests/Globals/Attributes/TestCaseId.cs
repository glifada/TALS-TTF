namespace TelerikAcademy.Core.Attributes
{
    using System;

    public class TestCaseId : Attribute
    {
        private readonly string testCaseId;

        public TestCaseId(string testCaseId)
        {
            this.testCaseId = testCaseId;
        }
    }
}
