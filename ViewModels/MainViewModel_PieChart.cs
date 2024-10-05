using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView.Extensions;


namespace AvaLiveCharts.ViewModels;

public partial class MainViewModel : ObservableObject

{
    // public ISeries[] PieSeries { get; set; } =
    // {
    //     new PieSeries<int> { Values = new int[] { 5 } },
    //     new PieSeries<int> { Values = new int[] { 9 } },
    //     new PieSeries<int> { Values = new int[] { 1 } },
    //     new PieSeries<int> { Values = new int[] { 4 } }
    // };


    private static int _index = 0;
    private static string[] _names = new[] { "Maria", "Susan", "Charles", "Fiona", "George" };

    public IEnumerable<ISeries> PieSeries { get; set; } =
         new[] { 8, 6, 5, 3, 3 }.AsPieSeries((value, pieSeries) =>
         {
             pieSeries.Name = _names[_index++ % _names.Length];
             pieSeries.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer;
             pieSeries.DataLabelsSize = 11;
             pieSeries.DataLabelsPaint = new SolidColorPaint(new SKColor(230, 230, 230));
             pieSeries.DataLabelsFormatter =
                point =>
                    $"This slide takes {point.Coordinate.PrimaryValue} " +
                    $"out of {point.StackedValue!.Total} parts";
             pieSeries.ToolTipLabelFormatter = point => $"{point.StackedValue!.Share:P2}";

             pieSeries.InnerRadius = 50;
             //pieSeries.Pushout = 0 ;
             pieSeries.OuterRadiusOffset = 25;

         });

}