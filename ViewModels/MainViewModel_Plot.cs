
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel.Sketches;
using SkiaSharp;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;


using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Legends;
using OxyPlot.Axes;
using LiveChartsCore.Drawing;
using LiveChartsCore.SkiaSharpView.Painting.Effects;


namespace AvaLiveCharts.ViewModels;


public partial class MainViewModel : ViewModelBase
{

    private readonly Random _random2 = new();
    private readonly List<DateTimePoint> _values = new();

    private readonly List<DateTimePoint> _values2 = new();

    private readonly List<DateTimePoint> _values3 = new();

    private readonly List<DateTimePoint> _values4 = new();


    //private readonly DateTimeAxis _customAxis;
    private readonly LiveChartsCore.SkiaSharpView.DateTimeAxis _customAxis;


    public MainViewModel()
    {
        Series_Plot = new ObservableCollection<ISeries>
        {
            new LineSeries<DateTimePoint>
            {
                Values = _values,

                GeometryFill = null,
                GeometryStroke = null,
                GeometrySize = 0,

                LineSmoothness = 0,
                //AnimationsSpeed = null
                Fill = new SolidColorPaint(new SKColor(19, 250, 20, 80)),
                Stroke = new SolidColorPaint(new SKColor(20, 252, 23)) { StrokeThickness = 3 },
                
                //AnimationsSpeed = TimeSpan.FromMilliseconds(1000)
               
            },
            new LineSeries<DateTimePoint>
            {
                Values = _values2,
                GeometryStroke = null,
                GeometrySize = 0,
                LineSmoothness = 0,

                Stroke = new SolidColorPaint(new SKColor(250, 52, 23)) { StrokeThickness = 3 },
  //              Fill = new SolidColorPaint(new SKColor(240, 45, 20, 80)),

                Fill = new LinearGradientPaint([new SKColor(245, 45, 15), new SKColor(20, 10, 4,0)],
                new SKPoint(0.5f, 0),
                new SKPoint(0.5f, 1))
                //new SKPoint(0.5f, 1))

            },
            new LineSeries<DateTimePoint>
            {
                Values = _values3,
                GeometryStroke = null,
                GeometrySize = 0,
                LineSmoothness = 0,
                //Fill = null,
                Fill = new LinearGradientPaint([new SKColor(245, 45, 15), new SKColor(20, 10, 4,0)],
                new SKPoint(0.5f, 0),
                new SKPoint(0.5f, 1)),

                //Stroke = new SolidColorPaint(new SKColor(20, 152, 203)) { StrokeThickness = 3 },
                Stroke = new LinearGradientPaint([new SKColor(45, 64, 89), new SKColor(255, 212, 96)])
            {
                StrokeThickness = 10
            }
            },

            new LineSeries<DateTimePoint>
            {
                Values = _values4,
                GeometryStroke = null,
                GeometrySize = 0,
                LineSmoothness = 0,
                Fill = null,
                Stroke = new SolidColorPaint(new SKColor(120, 152, 203)) { StrokeThickness = 3 },
            }

        };


        _customAxis = new LiveChartsCore.SkiaSharpView.DateTimeAxis(TimeSpan.FromSeconds(10), Formatter)
        {
            CustomSeparators = GetSeparators(),
            AnimationsSpeed = TimeSpan.FromMilliseconds(0),
            //AnimationsSpeed = null,
            SeparatorsPaint = new SolidColorPaint(SKColors.Silver.WithAlpha(100)),
            //SeparatorsPaint = new SolidColorPaint(SKColors.Red.WithAlpha(100))
            //AnimationsSpeed = TimeSpan.FromMilliseconds(5000)
        };

        XAxes = new LiveChartsCore.SkiaSharpView.Axis[] { _customAxis };

        _ = ReadData();






        //---------------------------------------------------------------------------------------------------------------------

        // ===> For OxyPlot <====================================================================================

        //---------------------------------------------------------------------------------------------------------------------


        // Create the plot model

        // LegendPlacement="Outside"
        //                   LegendPosition="TopCenter"
        //                   LegendOrientation="Horizontal"
        //                   LegendBorderThickness="0"
        //                   PlotAreaBorderThickness="0"


        var tmp = new PlotModel
        {
            Title = "THE CHART",
            Subtitle = "using OxyPlot",
            PlotAreaBorderColor = OxyColors.Silver,
            TextColor = OxyColors.Silver,


        };

        // Create two line series (markers are hidden by default)
        var series1 = new LineSeries
        {
            Title = "CO2 [ppm]",
            MarkerType = MarkerType.Circle,
            MarkerSize = 4,
            MarkerStroke = OxyColors.White,

        };
        series1.Points.Add(new DataPoint(0, 0));
        series1.Points.Add(new DataPoint(10, 18));
        series1.Points.Add(new DataPoint(20, 12));
        series1.Points.Add(new DataPoint(30, 8));
        series1.Points.Add(new DataPoint(40, 15));

        // ---

        var series2 = new LineSeries
        {
            Title = "Hum [%]",
            MarkerType = MarkerType.Square,
            MarkerSize = 4,
            MarkerStroke = OxyColors.Red
        };
        series2.Points.Add(new DataPoint(0, 4));
        series2.Points.Add(new DataPoint(10, 12));
        series2.Points.Add(new DataPoint(20, 16));
        series2.Points.Add(new DataPoint(30, 25));
        series2.Points.Add(new DataPoint(40, 5));


        // Add the series to the plot model
        tmp.Series.Add(series1);
        tmp.Series.Add(series2);


        //tmp.Legends.Add("VO2");       // Axes are created automatically if they are not defined

        // End for OxyPlot
        Legend legend = new Legend();
        legend.LegendTitle = "Legend";
        //legend.LegendPosition = LegendPosition.TopRight;
        legend.LegendPosition = LegendPosition.LeftTop;
        legend.LegendOrientation = LegendOrientation.Vertical;
        legend.LegendPlacement = LegendPlacement.Outside;
        legend.LegendSymbolPlacement = LegendSymbolPlacement.Left;
        tmp.Legends.Add(legend);
        tmp.IsLegendVisible = true;

        ///---
        ///var xAxis = new LinearAxis
        var xAxis = new LinearAxis
        {
            Title = "Time   [ s ]",
            Position = AxisPosition.Bottom,
            AxisTitleDistance = 20,
            MajorGridlineStyle = LineStyle.Solid,
            MinorGridlineStyle = LineStyle.Dot,
            MajorGridlineColor = OxyColor.FromRgb(60, 60, 60)      //      FromUInt32(0x909090) //OxyColors.GhostWhite
        };
        tmp.Axes.Add(xAxis);

        var yAxis = new LinearAxis
        {
            Title = "Y-Axis   [ V ]",
            AxisTitleDistance = 20,
            Position = AxisPosition.Left,
            MajorGridlineStyle = LineStyle.Solid,
            MinorGridlineStyle = LineStyle.Dot,
            MajorGridlineColor = OxyColor.FromRgb(60, 60, 60),
            MinorGridlineColor = OxyColor.FromRgb(60, 60, 60)
        };
        tmp.Axes.Add(yAxis);
        // Set the Model property, the INotifyPropertyChanged event will make the WPF Plot control update its content
        this.Model = tmp;
    }

    public ObservableCollection<ISeries> Series_Plot { get; set; }

    public LiveChartsCore.SkiaSharpView.Axis[] XAxes { get; set; }

    public object Sync { get; } = new object();

    public bool IsReading { get; set; } = true;

    private async Task ReadData()
    {
        // to keep this sample simple, we run the next infinite loop 
        // in a real application you should stop the loop/task when the view is disposed 

        int x = 0;
        int[] sinus = [128,130,132,135,137,139,141,144,146,148,150,152,155,157,159,161,163,165,168,170,172,174,176,178,180,182,184,186,188,190,192,
                        194,196,198,200,201,203,205,207,209,210,212,214,215,217,219,220,222,223,225,226,227,229,230,232,233,234,235,237,238,239,240,241,
                        242,243,244,245,246,247,247,248,249,250,250,251,252,252,253,253,254,254,254,255,255,255,256,256,256,256,256,256,256,256,256,256,
                        256,255,255,255,254,254,254,253,253,252,252,251,250,250,249,248,247,247,246,245,244,243,242,241,240,239,238,237,235,234,233,232,
                        230,229,227,226,225,223,222,220,219,217,215,214,212,210,209,207,205,203,201,200,198,196,194,192,190,188,186,184,182,180,178,176,
                        174,172,170,168,165,163,161,159,157,155,152,150,148,146,144,141,139,137,135,132,130,128,126,124,121,119,117,115,112,110,108,106,
                        104,101,99,97,95,93,91,88,86,84,82,80,78,76,74,72,70,68,66,64,62,60,58,56,55,53,51,49,47,46,44,42,
                        41,39,37,36,34,33,31,30,29,27,26,24,23,22,21,19,18,17,16,15,14,13,12,11,10,9,9,8,7,6,6,5,
                        4,4,3,3,2,2,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2,2,2,3,3,4,4,5,6,6,7,8,9,9,10,11,12,13,14,15,16,17,18,19,
                        21,22,23,24,26,27,29,30,31,33,34,36,37,39,41,42,44,46,47,49,51,53,55,56,58,60,62,64,66,68,70,72,
                        74,76,78,80,82,84,86,88,91,93,95,97,99,101,104,106,108,110,112,115,117,119,121,124,126
        ];

        while (IsReading)
        {
            await Task.Delay(33);

            // Because we are updating the chart from a different thread 
            // we need to use a lock to access the chart data. 
            // this is not necessary if your changes are made in the UI thread. 
            lock (Sync)
            {
                _values.Add(new DateTimePoint(DateTime.Now, (sinus[x])));
                _values2.Add(new DateTimePoint(DateTime.Now, x));
                _values3.Add(new DateTimePoint(DateTime.Now, (-sinus[x]) - 100));
                _values4.Add(new DateTimePoint(DateTime.Now, -200 - x));




                x++;
                x++;
                x++;

                if (x >= (sinus.Length)) { x = 0; }


                if (_values.Count > 300) _values.RemoveAt(0);
                if (_values2.Count > 300) _values2.RemoveAt(0);
                if (_values3.Count > 300) _values3.RemoveAt(0);
                if (_values4.Count > 300) _values4.RemoveAt(0);

                // we need to update the separators every time we add a new point 

                _customAxis.CustomSeparators = GetSeparators();
                //_customAxis.MinStep = 1;
                //_customAxis.CustomSeparators = new double[] { 0, 10, 25, 50, 100 };
                //_customAxis.MinLimit = 0; // forces the axis to start at 0
                //_customAxis.MaxLimit = 100; // forces the axis to end at 100

                _customAxis.SeparatorsPaint = new SolidColorPaint(SKColors.Silver.WithAlpha(80));
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

    public DrawMarginFrame Frame { get; set; } =
    new()
    {
        Fill = new SolidColorPaint(new SKColor(0x0b, 0x16, 0x1a, 0xff)),
        //Fill = new SolidColorPaint(new SKColor(4294634455u)),
        Stroke = new SolidColorPaint
        {
            Color = SKColors.Gray,
            StrokeThickness = 2
        }
    };


//--- lc2 ---

        public DrawMarginFrame lc2_Frame2 { get; set; } =
        new()
        {
            Fill = new SolidColorPaint(new SKColor(0x0b, 0x16, 0x1a, 0xff)),
      
            Stroke = new SolidColorPaint
            {
                Color = SKColors.Gray,
                StrokeThickness = 2
            }
        };


public ICartesianAxis[] lc2_XAxes { get; set; } = [
        new LiveChartsCore.SkiaSharpView.Axis
        {
            Name = "X axis",
            NamePaint = new SolidColorPaint(SKColors.Gray),
            TextSize = 18,
            Padding = new Padding(5, 15, 5, 5),
            LabelsPaint = new SolidColorPaint(SKColors.Silver),
            SeparatorsPaint = new SolidColorPaint
            {
                Color = SKColors.Silver.WithAlpha(70), // Line full number
                StrokeThickness = 0.7f,
                
            },
            SubseparatorsPaint = new SolidColorPaint
            {
                Color = SKColors.Silver.WithAlpha(60),
                StrokeThickness = 0.5f,
                PathEffect = new DashEffect([4, 6])
            },
            SubseparatorsCount = 1,
            ZeroPaint = new SolidColorPaint
            {
                Color = SKColors.Silver,
                StrokeThickness = 2
            },
            TicksPaint = new SolidColorPaint
            {
                Color = SKColors.Silver,
                StrokeThickness = 1.5f
            },
            SubticksPaint = new SolidColorPaint
            {
                Color = SKColors.DarkOrange,
                StrokeThickness = 1
            }
        }
    ];


}


