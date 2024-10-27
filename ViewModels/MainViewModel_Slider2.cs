using CommunityToolkit.Mvvm.ComponentModel;


namespace AvaLiveCharts.ViewModels;

public partial class MainViewModel : ViewModelBase


{
    [ObservableProperty]
    private string text_Slider_Value2 = "YYY";

    [ObservableProperty]
    private int sliderValue2 = 20;



    partial void OnSliderValue2Changed(int oldValue, int newValue)
    {
        Text_Slider_Value2 = newValue.ToString();
       
    }
}