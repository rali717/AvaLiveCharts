
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

/*
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

        // End for OxyPlo


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

    */