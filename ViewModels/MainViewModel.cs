
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


    
}
