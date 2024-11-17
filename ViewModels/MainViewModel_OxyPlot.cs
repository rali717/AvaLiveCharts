
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
using System.Collections.ObjectModel;
using OxyPlot;
using OxyPlot.Series;

namespace AvaLiveCharts.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    // For OxyPlot
    public PlotModel Model { get; private set; }
}