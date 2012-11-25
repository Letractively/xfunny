using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace XFunny.QFilter
{
    public enum CSTyteOperator
    {
        [Description("=")]
        Equals = 0,
        [Description("!=")]
        NotEquals = 1,
        [Description(">=")]
        GreaterEquals = 2,
        [Description(">")]
        Greater = 3,
        [Description("<=")]
        LessEquals = 4,
        [Description("<")]
        Less = 5
    }
}
