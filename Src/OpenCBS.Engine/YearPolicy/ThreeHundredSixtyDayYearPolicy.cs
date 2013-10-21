using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.YearPolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IYearPolicy))]
    [ExportMetadata("Order", 20)]
    [PolicyAttribute(PolicyType = "YearPolicy", Implementation = "360")]
    public class ThreeHundredSixtyDayYearPolicy : BasePolicy, IYearPolicy
    {
        public int GetNumberOfDays(DateTime date)
        {
            return 360;
        }

        public override string Name
        {
            get { return "360 days"; }
        }
    }
}
