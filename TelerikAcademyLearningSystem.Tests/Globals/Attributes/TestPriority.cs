namespace TelerikAcademy.Core.Attributes
{
    using System;

    public class TestPriority : Attribute
    {
        private readonly string priority;

        public TestPriority(string priority)
        {
            this.priority = priority;
        }
    }
}
