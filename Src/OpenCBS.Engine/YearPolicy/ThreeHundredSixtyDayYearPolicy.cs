using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.YearPolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IYearPolicy))]
    [ExportMetadata("Order", 20)]
    [PolicyAttribute(Implementation = "360 days")]
    public class ThreeHundredSixtyDayYearPolicy : IYearPolicy
    {
        public int GetNumberOfDays(DateTime date)
        {
            return 360;
        }
    }
}
