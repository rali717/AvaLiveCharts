
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.VisualElements;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.Defaults;

namespace AvaLiveCharts.ViewModels;


public partial class MainViewModel : ViewModelBase
{
    private readonly Random _random = new();
    public static double sectionsOuter = 130;
    public static double sectionsWidth = 20;

    public static NeedleVisual Needle { get; set; } = new NeedleVisual
    {
        Value = 45,
        Fill = new SolidColorPaint(SKColors.LightSeaGreen.WithAlpha(90))
                    
    };

    

    public IEnumerable<ISeries> Series_AngularGauge { get; set; } =
    GaugeGenerator.BuildAngularGaugeSections(
        new GaugeItem(60, s => SetStyle(sectionsOuter, sectionsWidth, s)),
        new GaugeItem(30, s => SetStyle(sectionsOuter, sectionsWidth, s)),
        new GaugeItem(10, s => SetStyle(sectionsOuter, sectionsWidth, s)));

// pieSeries.DataLabelsPaint = new SolidColorPaint(new SKColor(230, 230, 230));

    public IEnumerable<VisualElement<SkiaSharpDrawingContext>> VisualElements { get; set; } =
    new VisualElement<SkiaSharpDrawingContext>[]{
            new AngularTicksVisual
            {
                LabelsSize = 16,
                LabelsOuterOffset = 15,
                OuterOffset = 65,
                TicksLength = 20,
                
                LabelsPaint = new SolidColorPaint(new SKColor(230, 230, 230)),
                Stroke = new SolidColorPaint(new SKColor(100, 100, 100)),


            },
            Needle
};


    //public IEnumerable<ISeries> Series_AngularGauge { get; set; }

    //public IEnumerable<VisualElement<SkiaSharpDrawingContext>> VisualElements { get; set; }



    [RelayCommand]
    public void DoRandomChange()
    {
        // modifying the Value property updates and animates the chart automatically
        Needle.Value = _random.Next(0, 100);
        Text_Slider_Value = Needle.Value.ToString();
        SliderValue = (int)Needle.Value;
    }

    private static void SetStyle(
        double sectionsOuter, double sectionsWidth, PieSeries<ObservableValue> series)
    {
        series.OuterRadiusOffset = sectionsOuter;
        series.MaxRadialColumnWidth = sectionsWidth;
    }

}

//     [ObservableProperty]
//     private string text_Slider_Value2 = "YYY";

//     [ObservableProperty]
//     private int sliderValue2 = 20;



//     partial void OnSliderValue2Changed(int oldValue, int newValue)
//     {
//         Text_Slider_Value2 = newValue.ToString();
//     }

