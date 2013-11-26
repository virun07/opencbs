
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.YearPolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IYearPolicy))]
    [ExportMetadata("Order", 30)]
    [PolicyAttribute(Implementation = "365 days")]
    public class ThreeHundredSixtyFiveDayYearPolicy : IYearPolicy
    {
        public int GetNumberOfDays(System.DateTime date)
        {
            return 365;
        }
    }
}
