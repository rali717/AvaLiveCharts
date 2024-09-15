namespace AvaLiveCharts.ViewModels;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.Drawing;

public partial class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";



    private static readonly SKColor s_blue = new(25, 118, 210);
    private static readonly SKColor s_red = new(229, 57, 53);
    private static readonly SKColor s_yellow = new(198, 167, 0);


    public ISeries[] Series { get; set; } 
            = new ISeries[]
            {
                new LineSeries<double, RectangleGeometry>
                {
                    Name = "Temperatur",
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 , 1, 3, 5, 3, 4, 6 , 1, 3, 5, 3, 4, 6 , 1, 3, 5, 3, 4, 6 , 1, 3, 5, 3, 4, 6},
                    Fill = new SolidColorPaint(SKColors.LightSeaGreen.WithAlpha(90)),
                    GeometrySize = 10,
                    LineSmoothness = 1, 
                    Stroke = new SolidColorPaint(s_red, 2),
                    GeometryStroke = new SolidColorPaint(s_blue, 2)
                },
                new LineSeries<double, SVGPathGeometry>
                {
                    Name = "Humity",
                    GeometrySvg = SVGPoints.Star,
                    Values = new double[] {  2, 2, 1, 3, 5, 3, 4, 3 , 1, 3, 5, 3, 4, 3 , 1, 3, 5, 3, 4, 6 , 1, 3, 5, 3, 4, 6 , 1, 3, 5 },
                    Fill = new SolidColorPaint(SKColors.LightGreen.WithAlpha(90)),
                    GeometrySize = 10,
                    LineSmoothness = 1, 
                    Stroke = new SolidColorPaint(s_blue, 2),
                    GeometryStroke = new SolidColorPaint(s_red, 2)
                },
                new LineSeries<double>
                {
                    Name = "CO2",
                    Values = new double[] { 7, 2, 7, 2, 2, 1, 3, 5, 3, 4, 3 , 1, 3, 5, 3, 4, 3 , 1, 3, 5, 3, 4, 6 , 1, 3, 5, 3, 4, 6 , 1, 3, 5 },
                    Fill = new SolidColorPaint(SKColors.Yellow.WithAlpha(90)),
                    GeometrySize = 4,
                    LineSmoothness = 0, 
                    Stroke = new SolidColorPaint(s_blue, 2),
                    GeometryStroke = new SolidColorPaint(s_red, 2)
                }
            };



public ICartesianAxis[] YAxes { get; set; } =
    {
        new Axis // the "units" and "tens" series will be scaled on this axis
        {
            Name = "Tens",
            NameTextSize = 14,
            NamePaint = new SolidColorPaint(s_blue),
            NamePadding = new LiveChartsCore.Drawing.Padding(0, 20),
            Padding =  new LiveChartsCore.Drawing.Padding(0, 0, 20, 0),
            TextSize = 12,
            LabelsPaint = new SolidColorPaint(s_blue),
            TicksPaint = new SolidColorPaint(s_blue),
            SubticksPaint = new SolidColorPaint(s_blue),
            DrawTicksPath = true
        },
        new Axis // the "hundreds" series will be scaled on this axis
        {
            Name = "Hundreds",
            NameTextSize = 14,
            NamePaint = new SolidColorPaint(s_red),
            NamePadding = new LiveChartsCore.Drawing.Padding(0, 20),
            Padding =  new LiveChartsCore.Drawing.Padding(20, 0, 0, 0),
            TextSize = 12,
            LabelsPaint = new SolidColorPaint(s_red),
            TicksPaint = new SolidColorPaint(s_red),
            SubticksPaint = new SolidColorPaint(s_red),
            DrawTicksPath = true,
            ShowSeparatorLines = false,
            Position = LiveChartsCore.Measure.AxisPosition.End
        }
    };
#pragma warning restore CA1822 // Mark members as static
}
