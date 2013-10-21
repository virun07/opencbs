
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.YearPolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IYearPolicy))]
    [ExportMetadata("Order", 30)]
    [PolicyAttribute(PolicyType = "YearPolicy", Implementation = "365")]
    public class ThreeHundredSixtyFiveDayYearPolicy : BasePolicy, IYearPolicy
    {
        public int GetNumberOfDays(System.DateTime date)
        {
            return 365;
        }

        public override string Name
        {
            get { return "365 days"; }
        }
    }
}
