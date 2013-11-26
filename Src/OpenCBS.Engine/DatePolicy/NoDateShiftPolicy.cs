using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.DatePolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IDateShiftPolicy))]
    [ExportMetadata("Order", 10)]
    [PolicyAttribute(Implementation = "No shift")]
    public class NoDateShiftPolicy : IDateShiftPolicy
    {
        public DateTime ShiftDate(DateTime date)
        {
            return date;
        }
    }
}
