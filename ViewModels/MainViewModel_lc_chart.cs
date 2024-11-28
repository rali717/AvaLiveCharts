
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
using LiveChartsCore.Drawing;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using Axis = LiveChartsCore.SkiaSharpView.Axis;

namespace AvaLiveCharts.ViewModels;


public partial class MainViewModel : ViewModelBase
{



    private static readonly SKColor s_blue = new(25, 118, 210);
    private static readonly SKColor s_red = new(229, 57, 53);
    private static readonly SKColor s_yellow = new(198, 167, 0);

    public ObservableCollection<ISeries> Series_Plot { get; set; }
    public LiveChartsCore.SkiaSharpView.Axis[] XAxes { get; set; }

    public ISeries[] Series { get; set; }
            = new ISeries[]
            {
                new LineSeries<double, RectangleGeometry>
                {
                    Name = "Temperatur",

                    Stroke = new SolidColorPaint(new SKColor(0xd0, 0x00, 0x00),2),
                    Fill = new LinearGradientPaint([new SKColor(0xdc, 0x5c, 0x1c, 70), new SKColor(0x48, 0x1e, 0x1e,0)], //481e1e
                        new SKPoint(0.5f, 0),
                        new SKPoint(0.5f, 1)),

                    GeometrySize = 5,
                    LineSmoothness = 1,
                    GeometryStroke = new SolidColorPaint(s_blue, 2),

                    Values = new double[] { 2, 4, 7, 5, 4, 4, 6 , 5, 3, 2, 3, 6, 2 }

                },
                new LineSeries<double, SVGPathGeometry>
                {
                    Name = "Humity",

                    Stroke = new SolidColorPaint(s_blue, 2),
                    LineSmoothness = 1,
                    Fill = new LinearGradientPaint([new SKColor(33, 163, 215), new SKColor(20, 10, 4,0)],
                        new SKPoint(0.5f, 0),
                        new SKPoint(0.5f, 1)),

                    GeometrySvg = SVGPoints.Star,
                    GeometryStroke = new SolidColorPaint(s_red, 2),
                    GeometrySize = 8,

                    Values = new double[] { 1, 2, 4, 3, 4, 6, 4, 2 , 1, 4, 5, 3, 1 }

                },

                new LineSeries<double>
                {
                    Name = "CO2",

                    Stroke = new SolidColorPaint(new SKColor(0x77, 0xdc, 0x48),2),
                    
                    //Fill = new LinearGradientPaint([new SKColor(0x43, 0x7c, 0x28), new SKColor(0x43, 0x7c, 0x28, 0)],//182c0e
                    Fill = new LinearGradientPaint([new SKColor(0x43, 0x7c, 0x28), new SKColor(0x18, 0x2c, 0x0e, 0)],//182c0e
                        new SKPoint(0.5f, 0),
                        new SKPoint(0.5f, 1)),

                    GeometrySize = 5,
                    LineSmoothness = 0,
                    GeometryStroke = new SolidColorPaint(s_red, 2),

                    Values = new double[] { 0, 1, 1, 2, 2, 1, 3, 3, 6, 5, 1 , 2, 0 },

                }
            };



    public SolidColorPaint LegendTextPaint { get; set; } =
        new SolidColorPaint
        {
            Color = new SKColor(200, 200, 200),
            SKTypeface = SKTypeface.FromFamilyName("Courier New")
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
            new Axis
        {
            Name = "X axis",
            NamePaint = new SolidColorPaint(SKColors.Silver),
            TextSize = 18,
            Padding = new Padding(5, 15, 5, 5),
            LabelsPaint = new SolidColorPaint(SKColors.Silver),

            ZeroPaint = new SolidColorPaint
            {
                Color = SKColors.Silver.WithAlpha(70),
                StrokeThickness = 1.5f
            },

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

            TicksPaint = new SolidColorPaint
            {
                Color = SKColors.Silver,
                StrokeThickness = 1.5f
            },
            SubticksPaint = new SolidColorPaint
            {
                Color = SKColors.Silver,
                StrokeThickness = 1
            }
        }
        ];


    public Axis[] lc2_YAxes { get; set; }
                = new Axis[]
                {
                new Axis
                {
                    Name = "Y Axis",
                    NamePaint = new SolidColorPaint(SKColors.Silver),

                    LabelsPaint = new SolidColorPaint(SKColors.Silver),
                    TextSize = 18,
                    Padding = new Padding(5, 5, 15, 5), // w,x, Abstand zur Achse, Z

                    ZeroPaint = new SolidColorPaint
                    {
                        Color = SKColors.Silver.WithAlpha(70),
                        StrokeThickness = 1.5f
                    },

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

                    TicksPaint = new SolidColorPaint
                    {
                        Color = SKColors.Silver,
                        StrokeThickness = 1.5f
                    },
                    SubticksPaint = new SolidColorPaint
                    {
                        Color = SKColors.Silver,
                        StrokeThickness = 1
                    }

                }
                };

    public SolidColorPaint lc2_LegendTextPaint { get; set; } =
        new SolidColorPaint
        {
            Color = new SKColor(200, 200, 200),
            SKTypeface = SKTypeface.FromFamilyName("Courier New")
        };


}


