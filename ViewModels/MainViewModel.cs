﻿
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.Drawing;
using LiveChartsCore.VisualElements;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;


using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.Defaults;






namespace AvaLiveCharts.ViewModels;

public partial class MainViewModel : ObservableObject
{

    private int _count;

    [ObservableProperty]
    private string? _userName = "UserName";

    [ObservableProperty]
    private string? _userNameOutput = "XXX";


    [ObservableProperty]
    private string greeting = "Welcome to Avalonia!";

    [ObservableProperty]
    private int sliderValue = 20;

    [ObservableProperty]
    private string text_Slider_Value = "XXX";





    [ObservableProperty]
    private int counter;


    [RelayCommand]
    private async Task DoLogin()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
        Greeting="Login success!";
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

}