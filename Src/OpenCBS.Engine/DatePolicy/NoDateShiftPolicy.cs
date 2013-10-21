using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.DatePolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IDateShiftPolicy))]
    [ExportMetadata("Order", 10)]
    [PolicyAttribute(Implementation = "No")]
    public class NoDateShiftPolicy : BasePolicy, IDateShiftPolicy
    {
        public DateTime ShiftDate(DateTime date)
        {
            return date;
        }

        public override string Name
        {
            get { return "No shift"; }
        }
    }
}
