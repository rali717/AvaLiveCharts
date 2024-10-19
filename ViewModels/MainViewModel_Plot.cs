
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Defaults;
using SkiaSharp;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace AvaLiveCharts.ViewModels;


public partial class MainViewModel : ObservableObject
{

    private readonly Random _random2 = new();
    private readonly List<DateTimePoint> _values = new();
    private readonly DateTimeAxis _customAxis;

    public MainViewModel()
    {
        Series_Plot = new ObservableCollection<ISeries>
        {
            new LineSeries<DateTimePoint>
            {
                Values = _values,
                //Fill = null,
                GeometryFill = null,
                GeometryStroke = null,
                GeometrySize = 0,
                //GeometryStroke = new SolidColorPaint(s_blue, 1),
                //GeometrySize = 2,
                //GeometryStroke = null,
                
                //Stroke = new SolidColorPaint(s_red, 1),
                LineSmoothness = 0,
                //AnimationsSpeed = null
                Fill = new SolidColorPaint(new SKColor(63, 77, 99)),
                Stroke = new SolidColorPaint(new SKColor(120, 152, 203)) { StrokeThickness = 3 },
            }
        };

        _customAxis = new DateTimeAxis(TimeSpan.FromSeconds(10), Formatter)
        {
            CustomSeparators = GetSeparators(),
            //AnimationsSpeed = TimeSpan.FromMilliseconds(0),
            AnimationsSpeed = null,
            SeparatorsPaint = new SolidColorPaint(SKColors.Black.WithAlpha(100))
            //SeparatorsPaint = new SolidColorPaint(SKColors.Red.WithAlpha(100))
        };

        XAxes = new Axis[] { _customAxis };

        _ = ReadData();

    }

    public ObservableCollection<ISeries> Series_Plot { get; set; }

    public Axis[] XAxes { get; set; }

    public object Sync { get; } = new object();

    public bool IsReading { get; set; } = true;

    private async Task ReadData()
    {
        // to keep this sample simple, we run the next infinite loop 
        // in a real application you should stop the loop/task when the view is disposed 

        while (IsReading)
        {
            await Task.Delay(16);

            // Because we are updating the chart from a different thread 
            // we need to use a lock to access the chart data. 
            // this is not necessary if your changes are made in the UI thread. 
            lock (Sync)
            {
                _values.Add(new DateTimePoint(DateTime.Now, _random2.Next(0, 10)));
                //if (_values.Count > 250) _values.RemoveAt(0);
                if (_values.Count > 500) _values.RemoveAt(0);

                // we need to update the separators every time we add a new point 
                _customAxis.CustomSeparators = GetSeparators();
            }
        }
    }

    private double[] GetSeparators()
    {
        var now = DateTime.Now;

        return new double[]
        {
            now.AddSeconds(-25).Ticks,
            now.AddSeconds(-20).Ticks,
            now.AddSeconds(-15).Ticks,
            now.AddSeconds(-10).Ticks,
            now.AddSeconds(-5).Ticks,
            now.Ticks
        };
    }

    private static string Formatter(DateTime date)
    {
        var secsAgo = (DateTime.Now - date).TotalSeconds;

        return secsAgo < 1
            ? "now"
            : $"{secsAgo:N0}s ago";
    }
}


