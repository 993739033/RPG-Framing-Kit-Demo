using System;

namespace Test.Attribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AttributeTest : System.Attribute
    {
        public TestType type { get; set; }
    }
}