

using System;

namespace AvaLiveCharts.ViewModels;

public class Measurement
{
    public double Time { get; set; }
    public double Value { get; set; }
    public double Minimum { get; set; }
    public double Maximum { get; set; }

    public override string ToString()
    {
        return String.Format("{0:#0.0} {1:##0.0}", Time, Value);
    }
}
