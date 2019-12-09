using System;

namespace Utilities.Extensions.Test
{
    //http://hamidmosalla.com/2018/08/16/xunit-control-the-test-execution-order/
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestPriorityAttribute : Attribute
    {
        public TestPriorityAttribute(int priority)
        {
            Priority = priority;
        }

        public int Priority { get; private set; }
    }
}