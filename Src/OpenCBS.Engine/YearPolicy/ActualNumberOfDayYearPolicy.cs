using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.YearPolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IYearPolicy))]
    [ExportMetadata("Order", 10)]
    [PolicyAttribute(PolicyType = "YearPolicy", Implementation = "Actual")]
    public class ActualNumberOfDayYearPolicy : BasePolicy, IYearPolicy
    {
        public int GetNumberOfDays(DateTime date)
        {
            return DateTime.IsLeapYear(date.Year) ? 366 : 365;
        }

        public override string Name
        {
            get { return "Actual"; }
        }
    }
}
