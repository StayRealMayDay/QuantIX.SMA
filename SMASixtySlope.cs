using System;
using QuantTC;
using QuantTC.Indicators.Generic;

namespace QuantIX.SMA
{
    public class SMASixtySlope : Indicator<int>
    {
        public SMASixtySlope(IIndicator<double> source)
        {
            Source = source;
            Source.Update += SourceOnUpdate;
        }

        private void SourceOnUpdate()
        {
            Data.FillRange(Count, Source.Count, i => i > 0 ? (int)(Source[i] + 0.5) - (int)(Source[i - 1] + 0.5) : 0);
            FollowUp();
        }


        public IIndicator<double> Source { get; }
    }
}