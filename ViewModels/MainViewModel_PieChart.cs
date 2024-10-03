using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.Drawing;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.VisualElements;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.Defaults;



namespace AvaLiveCharts.ViewModels;

public partial class MainViewModel : ObservableObject

{
    public ISeries[] PieSeries { get; set; } =
    {
        new PieSeries<int> { Values = new int[] { 10, } },
        new PieSeries<int> { Values = new int[] { 6 } },
        new PieSeries<int> { Values = new int[] { 4 } }
    };

}