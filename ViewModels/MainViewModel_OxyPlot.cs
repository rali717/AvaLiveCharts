
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
using OxyPlot.Legends;
using OxyPlot.Axes;

namespace AvaLiveCharts.ViewModels;


// ---  OxyPlot  --------------------------------------------------------------

public partial class MainViewModel : ViewModelBase
{
    public PlotModel OxyPlotModel { get; private set; } = new PlotModel { Title = "Simple example", Subtitle = "using OxyPlot" };

    public LineSeries series1 = new LineSeries
    {
        Title = "CO2 [ppm]",
        MarkerType = MarkerType.Circle,
        MarkerSize = 4,
        MarkerStroke = OxyColors.White,

        MarkerFill = OxyColors.LightBlue, // Marker fill color 
        Color = OxyColors.SteelBlue, // Line color 
        StrokeThickness = 2, // Line thickness 
        LineStyle = LineStyle.Solid, // Line style (e.g., Solid, Dash, Dot) 
    };

    public LineSeries series2 = new LineSeries
    {
        Title = "Hum [%]",
        MarkerType = MarkerType.Square,
        MarkerSize = 4,
        MarkerStroke = OxyColors.Red,
        MarkerFill = OxyColors.LightBlue, // Marker fill color 
        Color = OxyColors.SteelBlue, // Line color 
        StrokeThickness = 2, // Line thickness 
        LineStyle = LineStyle.Solid, // Line style (e.g., Solid, Dash, Dot)
    };


    public LinearAxis xAxis = new LinearAxis
    {
        Title = "Time   [ s ]",
        Position = AxisPosition.Bottom,
        AxisTitleDistance = 20,
        MajorGridlineStyle = LineStyle.Solid,
        MinorGridlineStyle = LineStyle.Dot,
        MajorGridlineColor = OxyColor.FromRgb(60, 60, 60)
        // IsZoomEnabled = true,
        // Zoom(0, 100); // Set initial zoom range   

    };


    public LinearAxis yAxis = new LinearAxis
    {
        Title = "Y-Axis   [ V ]",
        AxisTitleDistance = 20,
        Position = AxisPosition.Left,
        MajorGridlineStyle = LineStyle.Solid,
        MinorGridlineStyle = LineStyle.Dot,
        MajorGridlineColor = OxyColor.FromRgb(60, 60, 60),
        MinorGridlineColor = OxyColor.FromRgb(60, 60, 60)
    };


    public Legend legend = new Legend();

    public void init_oxyplot()
    {
        PlotModel tmpPlotModel = new PlotModel();

        tmpPlotModel.Title = "THE CHART";
        tmpPlotModel.TitleFontSize = 18;
        tmpPlotModel.TitleColor = OxyColor.Parse("#FFFF0000");
        tmpPlotModel.Subtitle = "using OxyPlot";
        tmpPlotModel.TextColor = OxyColors.Silver;

        tmpPlotModel.PlotAreaBorderThickness=new OxyThickness(0,0,0,0); // Left,Top,Right,Bottom
        tmpPlotModel.PlotAreaBorderColor = OxyColor.FromRgb(0x0b, 0x16, 0x1a);

        series1.Points.Add(new DataPoint(0, 0));
        series1.Points.Add(new DataPoint(10, 18));
        series1.Points.Add(new DataPoint(20, 12));
        series1.Points.Add(new DataPoint(30, 8));
        series1.Points.Add(new DataPoint(40, 15));

        // ---

        series2.Points.Add(new DataPoint(0, 4));
        series2.Points.Add(new DataPoint(10, 12));
        series2.Points.Add(new DataPoint(20, 16));
        series2.Points.Add(new DataPoint(30, 25));
        series2.Points.Add(new DataPoint(40, 5));


        legend.LegendTitle = "Legend";
        legend.TextColor = OxyColors.Silver;

        legend.LegendPosition = LegendPosition.LeftTop;
        legend.LegendOrientation = LegendOrientation.Vertical;
        legend.LegendPlacement = LegendPlacement.Outside;
        legend.LegendSymbolPlacement = LegendSymbolPlacement.Left;

        tmpPlotModel.Legends.Add(legend);
        tmpPlotModel.IsLegendVisible = true;

        tmpPlotModel.Series.Add(series1);
        tmpPlotModel.Series.Add(series2);

        tmpPlotModel.Axes.Add(xAxis);
        tmpPlotModel.Axes.Add(yAxis);

        // Set the Model property, the INotifyPropertyChanged event will make the WPF Plot control update its content
        this.OxyPlotModel = tmpPlotModel;
    }

};

