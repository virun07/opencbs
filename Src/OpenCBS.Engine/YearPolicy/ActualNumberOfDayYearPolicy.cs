using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.YearPolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IYearPolicy))]
    [ExportMetadata("Order", 10)]
    [PolicyAttribute(Implementation = "Actual")]
    public class ActualNumberOfDayYearPolicy : IYearPolicy
    {
        public int GetNumberOfDays(DateTime date)
        {
            return DateTime.IsLeapYear(date.Year) ? 366 : 365;
        }
    }
}
