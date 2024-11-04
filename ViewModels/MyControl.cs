
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

namespace AvaLiveCharts.ViewModels;


public partial class MyControl : ViewModelBase
{

    [ObservableProperty] public string buttonContent = "  Click me !  ";

    partial void OnButtonContentChanged(string value)
    {
        ButtonContent = "Clicked!";
    }



    private bool CanClick() => ButtonContent == "CLICKED";


// partial void  OnButtonClicked (){
//     ButtonContent = "Clicked!";
// }


    // [RelayCommand]
    // private void SetTextBoxContent(string name)
    // {
    //     TextBoxContent = $"Moin, {name}";
    // }

[RelayCommand] public void OnButtonClicked(){
ButtonContent ="Moin";
}

}