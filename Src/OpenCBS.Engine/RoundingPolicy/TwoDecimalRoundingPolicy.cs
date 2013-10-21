using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.RoundingPolicy
{
    [Export(typeof(IPolicy))]
    [Export(typeof(IRoundingPolicy))]
    [ExportMetadata("Order", 10)]
    [PolicyAttribute(Implementation = "Two decimal")]
    public class TwoDecimalRoundingPolicy : BasePolicy, IRoundingPolicy
    {
        public decimal Round(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }

        public override string Name
        {
            get { return "Two decimal"; }
        }
    }
}
