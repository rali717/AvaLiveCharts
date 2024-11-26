
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.Drawing;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;


namespace AvaLiveCharts.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    [ObservableProperty] private string? buttonContent = "The Button";

    private int _count;

    [ObservableProperty] private string? _userName = "UserName";


    [ObservableProperty] private string? _userNameOutput = "XXX";


    [ObservableProperty] private string greeting = "Welcome to Avalonia, with  \n* MVVM-CommunityToolkit\n* LiveCharts-2\n and \n* OxyPlot   ";


    [ObservableProperty] private int sliderValue = 20;


    [ObservableProperty] private string text_Slider_Value = "XXX";


    [ObservableProperty] private int counter;


    [RelayCommand]
    private async Task DoLogin()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
        Greeting = "Login success!";
    }

    partial void OnUserNameChanged(string? value)
    {
        UserNameOutput = value;
    }

    partial void OnGreetingChanged(string? oldValue, string newValue)
    {
        _count++;
        throw new System.NotImplementedException();
    }

    partial void OnCounterChanged(int oldValue, int newValue)
    {
        throw new System.NotImplementedException();
    }

    partial void OnSliderValueChanged(int oldValue, int newValue)
    {

        Text_Slider_Value = newValue.ToString();

        Needle.Value = newValue;
    }




    [RelayCommand]
    private void SetGreeting(string name)
    {
        Greeting = $"Moin, {name}";
    }


    private static readonly SKColor s_blue = new(25, 118, 210);
    private static readonly SKColor s_red = new(229, 57, 53);
    private static readonly SKColor s_yellow = new(198, 167, 0);


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

}
