using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.RoundingPolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IRoundingPolicy))]
    [ExportMetadata("Order", 20)]
    [PolicyAttribute(Implementation = "Whole")]
    public class IntegerRoundingPolicy : BasePolicy, IRoundingPolicy
    {
        public decimal Round(decimal amount)
        {
            return Math.Round(amount, 0, MidpointRounding.AwayFromZero);
        }

        public override string Name
        {
            get { return "Whole"; }
        }
    }
}
